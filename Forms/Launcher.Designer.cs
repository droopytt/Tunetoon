using System.Windows.Forms;
using Tunetoon.Grid;

namespace Tunetoon.Forms
{
    partial class Launcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.TopMenu = new MenuStrip();
            this.serverMenuItem = new ToolStripMenuItem();
            this.ServerMenuStrip = new ContextMenuStrip(components);
            this.rewrittenMenuItem = new ToolStripMenuItem();
            this.clashMenuItem = new ToolStripMenuItem();
            this.optionsMenuItem = new ToolStripMenuItem();
            this.endSelectedMenuItem = new ToolStripMenuItem();
            this.endAllMenuItem = new ToolStripMenuItem();
            this.untickAllMenuItem = new ToolStripMenuItem();
            this.resizeAllMenuItem = new ToolStripMenuItem();
            this.LoginButton = new Button();
            this.accountGrid = new AccountGrid();
            this.Login = new DataGridViewCheckBoxColumn();
            this.Toon = new DataGridViewTextBoxColumn();
            this.ToonSlots = new DataGridViewComboBoxColumn();
            this.End = new DataGridViewCheckBoxColumn();
            this.TopMenu.SuspendLayout();
            this.ServerMenuStrip.SuspendLayout();
            this.((System.ComponentModel.ISupportInitialize)accountGrid).BeginInit();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.AllowMerge = false;
            this.TopMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TopMenu.Items.AddRange(new ToolStripItem[] { serverMenuItem, optionsMenuItem, endSelectedMenuItem, endAllMenuItem, untickAllMenuItem, resizeAllMenuItem });
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Padding = new Padding(7, 2, 0, 2);
            this.TopMenu.Size = new System.Drawing.Size(623, 24);
            this.TopMenu.TabIndex = 0;
            this.TopMenu.Text = "TopMenu";
            this.TopMenu.Click += TopMenu_Click;
            // 
            // serverMenuItem
            // 
            this.serverMenuItem.DropDown = ServerMenuStrip;
            this.serverMenuItem.Name = "serverMenuItem";
            this.serverMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverMenuItem.Text = "Server";
            // 
            // ServerMenuStrip
            // 
            this.ServerMenuStrip.Items.AddRange(new ToolStripItem[] { rewrittenMenuItem, clashMenuItem });
            this.ServerMenuStrip.Name = "ServerMenuStrip";
            this.ServerMenuStrip.OwnerItem = serverMenuItem;
            this.ServerMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // rewrittenMenuItem
            // 
            this.rewrittenMenuItem.Checked = true;
            this.rewrittenMenuItem.CheckState = CheckState.Checked;
            this.rewrittenMenuItem.Name = "rewrittenMenuItem";
            this.rewrittenMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rewrittenMenuItem.Text = "Rewritten";
            this.rewrittenMenuItem.Click += Rewritten_Click;
            // 
            // clashMenuItem
            // 
            this.clashMenuItem.Name = "clashMenuItem";
            this.clashMenuItem.Size = new System.Drawing.Size(124, 22);
            this.clashMenuItem.Text = "Clash";
            this.clashMenuItem.Click += Clash_Click;
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += Options_Click;
            // 
            // endSelectedMenuItem
            // 
            this.endSelectedMenuItem.Name = "endSelectedMenuItem";
            this.endSelectedMenuItem.Size = new System.Drawing.Size(86, 20);
            this.endSelectedMenuItem.Text = "End Selected";
            this.endSelectedMenuItem.Visible = false;
            this.endSelectedMenuItem.Click += EndSelected_Click;
            // 
            // endAllMenuItem
            // 
            this.endAllMenuItem.Name = "endAllMenuItem";
            this.endAllMenuItem.Size = new System.Drawing.Size(56, 20);
            this.endAllMenuItem.Text = "End All";
            this.endAllMenuItem.Click += EndAll_Click;
            // 
            // untickAllMenuItem
            // 
            this.untickAllMenuItem.Name = "untickAllMenuItem";
            this.untickAllMenuItem.Size = new System.Drawing.Size(70, 20);
            this.untickAllMenuItem.Text = "Untick All";
            this.untickAllMenuItem.Click += UntickAll_Click;
            // 
            // resizeAllMenuItem
            // 
            this.resizeAllMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.resizeAllMenuItem.Name = "resizeAllMenuItem";
            this.resizeAllMenuItem.Size = new System.Drawing.Size(68, 20);
            this.resizeAllMenuItem.Text = "Resize All";
            this.resizeAllMenuItem.Click += ResizeAll_Click;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(14, 327);
            this.LoginButton.Margin = new Padding(4, 3, 4, 3);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(600, 29);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Play";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += LoginButton_Click;
            // 
            // accountGrid
            // 
            this.accountGrid.AllowDrop = true;
            this.accountGrid.AllowUserToResizeColumns = false;
            this.accountGrid.AllowUserToResizeRows = false;
            this.accountGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.accountGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountGrid.Columns.AddRange(new DataGridViewColumn[] { Login, Toon, ToonSlots, End });
            this.accountGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            this.accountGrid.Location = new System.Drawing.Point(14, 31);
            this.accountGrid.Margin = new Padding(4, 3, 4, 3);
            this.accountGrid.Name = "accountGrid";
            this.accountGrid.ScrollBars = ScrollBars.Vertical;
            this.accountGrid.ShowCellToolTips = false;
            this.accountGrid.Size = new System.Drawing.Size(600, 288);
            this.accountGrid.TabIndex = 3;
            this.accountGrid.CellMouseUp += AccGrid_OnCellMouseUp;
            this.accountGrid.CellValueChanged += AccGrid_CellValueChanged;
            this.accountGrid.DataBindingComplete += AccGrid_DataBindingComplete;
            this.accountGrid.UserDeletingRow += AccGrid_UserDeletingRow;
            this.accountGrid.DragDrop += AccGrid_DragDrop;
            // 
            // Login
            // 
            this.Login.DataPropertyName = "LoginWanted";
            this.Login.HeaderText = "Login?";
            this.Login.Name = "Login";
            this.Login.Width = 50;
            // 
            // Toon
            // 
            this.Toon.DataPropertyName = "Toon";
            this.Toon.HeaderText = "Toon";
            this.Toon.Name = "Toon";
            this.Toon.ReadOnly = true;
            // 
            // ToonSlots
            // 
            this.ToonSlots.HeaderText = "Jump to";
            this.ToonSlots.Name = "ToonSlots";
            this.ToonSlots.Width = 125;
            // 
            // End
            // 
            this.End.DataPropertyName = "EndWanted";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            this.End.DefaultCellStyle = dataGridViewCellStyle1;
            this.End.HeaderText = "End?";
            this.End.Name = "End";
            this.End.ReadOnly = true;
            this.End.Width = 50;
            // 
            // Launcher
            // 
            this.AcceptButton = LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 362);
            this.Controls.Add(accountGrid);
            this.Controls.Add(LoginButton);
            this.Controls.Add(TopMenu);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MainMenuStrip = TopMenu;
            this.Margin = new Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Tunetoon";
            this.Load += Launcher_Load;
            this.Shown += Launcher_Shown;
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ServerMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)accountGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private MenuStrip TopMenu;
        private Button LoginButton;
        private AccountGrid accountGrid;
        private ToolStripMenuItem endAllMenuItem;
        private ToolStripMenuItem untickAllMenuItem;
        private ToolStripMenuItem optionsMenuItem;
        private ToolStripMenuItem endSelectedMenuItem;
        private ToolStripMenuItem serverMenuItem;
        private ContextMenuStrip ServerMenuStrip;
        private ToolStripMenuItem rewrittenMenuItem;
        private ToolStripMenuItem clashMenuItem;
        private DataGridViewCheckBoxColumn Login;
        private DataGridViewTextBoxColumn Toon;
        private DataGridViewComboBoxColumn ToonSlots;
        private DataGridViewCheckBoxColumn End;
        private ToolStripMenuItem resizeAllMenuItem;
    }
}