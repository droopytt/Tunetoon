﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tunetoon.Accounts;
using Tunetoon.DioExtreme;
using Tunetoon.Encrypt;
using Tunetoon.Game;
using Tunetoon.Grid;
using Tunetoon.Login;
using Tunetoon.Patcher;
using Tunetoon.Utilities;

namespace Tunetoon.Forms
{
    public partial class Launcher : Form
    {
        private DataHandler dataHandler = new DataHandler();

        private BindingList<RewrittenAccount> rewrittenAccountList = new BindingList<RewrittenAccount>();
        private BindingList<ClashAccount> clashAccountList = new BindingList<ClashAccount>();
        private dynamic currentAccountList;

        private BindingSource bindingSource = new BindingSource();

        // Patchers
        private RewrittenPatcher rewrittenPatcher;
        private ClashPatcher clashPatcher;
        private IPatcher gamePatcher;

        // Login handlers
        private RewrittenLoginHandler rewrittenLoginHandler = new RewrittenLoginHandler();
        private ClashLoginHandler clashLoginHandler = new ClashLoginHandler();
        private dynamic loginHandler;

        // Game handlers
        private RewrittenGameHandler rewrittenGameHandler;
        private ClashGameHandler clashGameHandler;
        private dynamic gameHandler;

        // UI handlers
        private RewrittenGridHandler rewrittenGridHandler = new RewrittenGridHandler();
        private ClashGridHandler clashGridHandler = new ClashGridHandler();
        private IGridHandler gridHandler;

        private AccountEdit accountEdit = new AccountEdit();

        private Config config;

        public Launcher()
        {
            config = dataHandler.LoadConfig("Config.json");
            dataHandler.LoadClashIngameToons(config);

            bindingSource.ListChanged += BindingSource_ListChanged;
            accountEdit.Edited += AccountEditComplete;

            InitializeComponent();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            var accountDecryptor = new AccountDecryptor();
            accountDecryptor.OnPassedAuthentication += onPassedAuthentication;
            accountDecryptor.Authenticate(config);
        }

        public void onPassedAuthentication(BindingList<RewrittenAccount> rewrittenAccountList, BindingList<ClashAccount> clashAccountList)
        {
            this.rewrittenAccountList = rewrittenAccountList;
            this.clashAccountList = clashAccountList;

            dataHandler.FindClashIngameToons(clashAccountList);

            rewrittenPatcher = new RewrittenPatcher(config);
            clashPatcher = new ClashPatcher(config);
            rewrittenGameHandler = new RewrittenGameHandler(config);
            clashGameHandler = new ClashGameHandler(config);

            HandleConfig();

            accountGrid.AutoGenerateColumns = false;
            bindingSource.DataSource = currentAccountList;
            accountGrid.DataSource = bindingSource;
        }

        private void HandleConfig()
        {
            if (config.GameServer == Server.Rewritten)
            {
                currentAccountList = rewrittenAccountList;
                gamePatcher = rewrittenPatcher;
                loginHandler = rewrittenLoginHandler;
                gameHandler = rewrittenGameHandler;
                gridHandler = rewrittenGridHandler;
                rewrittenMenuItem.Checked = true;
                clashMenuItem.Checked = false;
                accountGrid.Columns[ToonSlots.Index].Visible = false;
            }
            else
            {
                currentAccountList = clashAccountList;
                gamePatcher = clashPatcher;
                loginHandler = clashLoginHandler;
                gameHandler = clashGameHandler;
                gridHandler = clashGridHandler;
                rewrittenMenuItem.Checked = false;
                clashMenuItem.Checked = true;
                accountGrid.Columns[ToonSlots.Index].Visible = true;
            }

            if (config.SelectEndGames)
            {
                endSelectedMenuItem.Visible = true;
                accountGrid.Columns[End.Index].ReadOnly = false;
            }
        }

        private void ReflectPatcherProgress(PatchProgress p)
        {
            Text = $"Tunetoon - {p.currentAction} Files {p.CurrentFilesProcessed}/{p.TotalFilesToProcess}";
        }

        private void ShowPatcherError(string text)
        {
            MessageBox.Show(text, "Game patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AssertPatcherError(string errorText)
        {
            if (gamePatcher.HasFailed())
            {
                throw new PatchException(errorText);
            }
        }

        private async Task RunPatcherAsync(Progress<PatchProgress> progress)
        {
            gamePatcher.Initialize(gamePatcher.GetGameDirectory());
            AssertPatcherError("Unable to create game directory. Check permissions or change the target directory.");

            gamePatcher.GetPatchManifest();
            AssertPatcherError("Could not retrieve patch manifest. The game has not been updated.");

            gamePatcher.CheckGameFiles(progress);

            await gamePatcher.DownloadGameFiles(progress);
            AssertPatcherError("An error occurred downloading update files. The game has not been updated.");

            gamePatcher.PatchGameFiles(progress);
            AssertPatcherError("An error occurred applying game patches. The game has not been updated.");
        }

        private async Task StartUpdate()
        {
            // Don't update if user does not want to or the game is running
            if (config.SkipUpdates || gameHandler.ActiveProcesses.Count > 0)
            {
                return;
            }

            LoginButton.Enabled = false;
            serverMenuItem.Enabled = false;
            LoginButton.Text = "Checking for updates...";

            try
            {
                var progress = new Progress<PatchProgress>(ReflectPatcherProgress);
                await Task.Run(() => RunPatcherAsync(progress));
            }
            catch (PatchException e)
            {
                ShowPatcherError(e.Message);
            }

            Text = "Tunetoon";
            LoginButton.Text = "Play";
            LoginButton.Enabled = true;
            serverMenuItem.Enabled = true;
        }

        private async void Launcher_Shown(object sender, EventArgs e)
        {
            if (config.GameServer == Server.Clash)
            {
                config.ClashUrls = ApiDataRetriever.LoadClashUrls();
            }
            await StartUpdate();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            // Workarounds some ComboBoxCell glitch
            // where the selection is not saved
            accountGrid.ClearGridSelections();

            if (config.GameServer == Server.Rewritten && !Directory.Exists(config.RewrittenPath) ||
                config.GameServer == Server.Clash && !Directory.Exists(config.ClashPath))
            {
                MessageBox.Show("Game directory missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            serverMenuItem.Enabled = false;
            LoginButton.Enabled = false;

            try
            {
                await loginHandler.LoginAccounts(currentAccountList);
                gameHandler.StartGameForLoggedInAccounts(currentAccountList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown: " + ex);
                MessageBox.Show("An error occured during the login process.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            serverMenuItem.Enabled = true;
            LoginButton.Enabled = true;
        }

        // Not aware of a good way to bind cell color to a boolean value
        // This mainly triggers by ListChanged which is triggered by
        // NotifyPropertyChanged
        public void ChangeEndCellColor(int index, Color color)
        {
            if (index < 0)
            {
                return;
            }

            // We can run this without actually selecting the cell itself
            // We need to set it to make edits on it though
            if (accountGrid.CurrentCell == null)
            {
                accountGrid.CurrentCell = accountGrid.Rows[index].Cells[End.Index];
            }

            accountGrid.BeginEdit(false);

            var chkCell = accountGrid.Rows[index].Cells[End.Index] as DataGridViewCheckBoxCell;
            chkCell.Style.BackColor = color;
            chkCell.Style.SelectionBackColor = color;

            if (!config.SelectEndGames)
            {
                chkCell.Value = chkCell.FalseValue;
            }

            accountGrid.EndEdit();
        }

        // Runs after the account list is changed.
        private void AccGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Trigger when the user changes servers
            // Logged in indicators have to be changed again
            if (e.ListChangedType == ListChangedType.Reset)
            {
                CheckLoggedIns(currentAccountList);
            }

            gridHandler.DataBindingComplete(accountGrid);
        }

        // Runs after NotifyPropertyChanged, see Account class
        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.NewIndex >= 0 && e.ListChangedType == ListChangedType.ItemChanged)
            {
                var account = currentAccountList[e.NewIndex];
                var color = account.LoggedIn ? Color.Green : Color.Red;
                ChangeEndCellColor(e.NewIndex, color);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.WindowsShutDown)
            {
                return;
            }

            dataHandler.SaveConfig(config, "Config.json");

            if (config.EncryptAccounts)
            {
                dataHandler.SaveEncrypted(rewrittenAccountList, Constants.ENCRYPTED_REWRITTEN_ACCOUNT_FILE_NAME);
                dataHandler.SaveEncrypted(clashAccountList, Constants.ENCRYPTED_CLASH_ACCOUNT_FILE_NAME);
            }
            else
            {
                dataHandler.SaveSerialized(rewrittenAccountList, Constants.REWRITTEN_ACCOUNT_FILE_NAME);
                dataHandler.SaveSerialized(clashAccountList, Constants.CLASH_ACCOUNT_FILE_NAME);
            }

            base.OnFormClosing(e);
        }

        private void AccGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            gridHandler.UserDeletingRow(e.Row.DataBoundItem);
        }

        private void AccGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != ToonSlots.Index)
            {
                return;
            }

            gridHandler.CellValueChanged(accountGrid, e.RowIndex);
        }

        // Runs after account info is returned from the editing form
        private void AccountEditComplete(dynamic account, int index)
        {
            currentAccountList[index] = account;
            if (account is ClashAccount && account.Authorized)
            {
                dataHandler.FindClashIngameToons(account);
            }
            bindingSource.ResetBindings(false);
        }

        // Handles account editing and game ending
        private void AccGrid_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != End.Index && e.ColumnIndex != Toon.Index)
            {
                return;
            }

            if (e.ColumnIndex == End.Index && e.RowIndex == accountGrid.NewRowIndex)
            {
                return;
            }

            var account = currentAccountList[e.RowIndex];

            if (e.ColumnIndex == Toon.Index && !accountGrid.MoveMode)
            {
                accountEdit.StartEdit(account, e.RowIndex);
            }
            else
            {
                if (!config.SelectEndGames && account.LoggedIn)
                {
                    gameHandler.StopGame(account);
                }
            }
        }

        private void AccGrid_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexToDrop = accountGrid.RowIndexToDrop;

            if (!accountGrid.RowIndexValid(rowIndexToDrop))
            {
                return;
            }

            var accountToMove = currentAccountList[rowIndexToDrop];
            var color = accountToMove.LoggedIn ? Color.Green : Color.Red;
            ChangeEndCellColor(rowIndexToDrop, color);
        }

        private void EndSelected_Click(object sender, EventArgs e)
        {
            foreach (var account in currentAccountList)
            {
                if (account != null && account.EndWanted && account.LoggedIn)
                {
                    gameHandler.StopGame(account);
                    account.EndWanted = false;
                }
            }
        }

        private void EndAll_Click(object sender, EventArgs e)
        {
            if (config.GlobalEndAll || config.GameServer == Server.Rewritten)
            {
                foreach (var acc in rewrittenAccountList)
                {
                    rewrittenGameHandler.StopGame(acc);
                }
            }

            if (config.GlobalEndAll || config.GameServer == Server.Clash)
            {
                foreach (var acc in clashAccountList)
                {
                    clashGameHandler.StopGame(acc);
                }
            }
        }

        private void UntickAll_Click(object sender, EventArgs e)
        {
            foreach (var account in currentAccountList)
            {
                account.LoginWanted = false;
            }
            accountGrid.ClearGridSelections();
        }

        public void SelectionOptionAltered()
        {
            if (config.SelectEndGames)
            {
                endSelectedMenuItem.Visible = true;
                accountGrid.Columns[End.Index].ReadOnly = false;
            }
            else
            {
                endSelectedMenuItem.Visible = false;
                accountGrid.Columns[End.Index].ReadOnly = true;
                foreach (DataGridViewRow row in accountGrid.Rows)
                {
                    var chk = (DataGridViewCheckBoxCell)row.Cells[End.Index];
                    chk.Value = false;
                }
            }
        }

        private void TopMenu_Click(object sender, EventArgs e)
        {
            accountGrid.ClearGridSelections();
        }

        private async void Rewritten_Click(object sender, EventArgs e)
        {
            config.GameServer = Server.Rewritten;
            HandleConfig();

            bindingSource.DataSource = rewrittenAccountList;
            bindingSource.ResetBindings(false);

            await StartUpdate();
        }

        private async void Clash_Click(object sender, EventArgs e)
        {
            config.GameServer = Server.Clash;

            if (!config.ClashUrls.Initialized)
            {
                config.ClashUrls = ApiDataRetriever.LoadClashUrls();
            }

            HandleConfig();

            bindingSource.DataSource = clashAccountList;
            bindingSource.ResetBindings(false);

            await StartUpdate();
        }

        private void CheckLoggedIns(dynamic accountList)
        {
            for (int i = 0; i < accountList.Count; ++i)
            {
                if (accountList[i].LoggedIn)
                {
                    ChangeEndCellColor(i, Color.Green);
                }
            }
        }

        private void Options_Click(object sender, EventArgs e)
        {
            Options optionWnd = new Options(this, config);
            optionWnd.ShowDialog();
        }

        private void MoveModeIntent(bool keyHeldDown)
        {
            if (keyHeldDown == false && config.SelectEndGames)
            {
                endSelectedMenuItem.Visible = true;
            }
            else
            {
                endSelectedMenuItem.Visible = false;
            }
            accountGrid.MoveMode = keyHeldDown;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            if (accountGrid.MoveMode)
            {
                MoveModeIntent(false);
            }
            base.OnDeactivate(e);
        }

        protected override bool ProcessKeyPreview(ref Message msg)
        {
            if ((Keys)msg.WParam != Keys.ControlKey)
            {
                return base.ProcessKeyPreview(ref msg);
            }

            const int KeyDown = 0x100;
            const int KeyUp = 0x101;

            if (!accountGrid.MoveMode && msg.Msg == KeyDown)
            {
                MoveModeIntent(true);
            }
            else if (accountGrid.MoveMode && msg.Msg == KeyUp)
            {
                MoveModeIntent(false);
            }

            return true;
        }

        private void ResizeAll_Click(object sender, EventArgs e)
        {
            if (rewrittenGameHandler.ActiveProcesses.Count == 0)
            {
                MessageBox.Show("What exactly are you resizing? There are no windows open!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            rewrittenGameHandler.ResizeAllWindows(currentAccountList);
        }
    }
}
