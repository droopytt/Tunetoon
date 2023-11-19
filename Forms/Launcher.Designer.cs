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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            TopMenu = new MenuStrip();
            serverMenuItem = new ToolStripMenuItem();
            ServerMenuStrip = new ContextMenuStrip(components);
            rewrittenMenuItem = new ToolStripMenuItem();
            clashMenuItem = new ToolStripMenuItem();
            optionsMenuItem = new ToolStripMenuItem();
            endSelectedMenuItem = new ToolStripMenuItem();
            endAllMenuItem = new ToolStripMenuItem();
            untickAllMenuItem = new ToolStripMenuItem();
            resizeAllMenuItem = new ToolStripMenuItem();
            LoginButton = new Button();
            accountGrid = new AccountGrid();
            Login = new DataGridViewCheckBoxColumn();
            Toon = new DataGridViewTextBoxColumn();
            ToonSlots = new DataGridViewComboBoxColumn();
            End = new DataGridViewCheckBoxColumn();
            TopMenu.SuspendLayout();
            ServerMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accountGrid).BeginInit();
            SuspendLayout();
            // 
            // TopMenu
            // 
            TopMenu.AllowMerge = false;
            TopMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            TopMenu.Items.AddRange(new ToolStripItem[] { serverMenuItem, optionsMenuItem, endSelectedMenuItem, endAllMenuItem, untickAllMenuItem, resizeAllMenuItem });
            TopMenu.Location = new System.Drawing.Point(0, 0);
            TopMenu.Name = "TopMenu";
            TopMenu.Padding = new Padding(7, 2, 0, 2);
            TopMenu.Size = new System.Drawing.Size(623, 24);
            TopMenu.TabIndex = 0;
            TopMenu.Text = "TopMenu";
            TopMenu.Click += TopMenu_Click;
            // 
            // serverMenuItem
            // 
            serverMenuItem.DropDown = ServerMenuStrip;
            serverMenuItem.Name = "serverMenuItem";
            serverMenuItem.Size = new System.Drawing.Size(51, 20);
            serverMenuItem.Text = "Server";
            // 
            // ServerMenuStrip
            // 
            ServerMenuStrip.Items.AddRange(new ToolStripItem[] { rewrittenMenuItem, clashMenuItem });
            ServerMenuStrip.Name = "ServerMenuStrip";
            ServerMenuStrip.OwnerItem = serverMenuItem;
            ServerMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // rewrittenMenuItem
            // 
            rewrittenMenuItem.Checked = true;
            rewrittenMenuItem.CheckState = CheckState.Checked;
            rewrittenMenuItem.Name = "rewrittenMenuItem";
            rewrittenMenuItem.Size = new System.Drawing.Size(124, 22);
            rewrittenMenuItem.Text = "Rewritten";
            rewrittenMenuItem.Click += Rewritten_Click;
            // 
            // clashMenuItem
            // 
            clashMenuItem.Name = "clashMenuItem";
            clashMenuItem.Size = new System.Drawing.Size(124, 22);
            clashMenuItem.Text = "Clash";
            clashMenuItem.Click += Clash_Click;
            // 
            // optionsMenuItem
            // 
            optionsMenuItem.Name = "optionsMenuItem";
            optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            optionsMenuItem.Text = "Options";
            optionsMenuItem.Click += Options_Click;
            // 
            // endSelectedMenuItem
            // 
            endSelectedMenuItem.Name = "endSelectedMenuItem";
            endSelectedMenuItem.Size = new System.Drawing.Size(86, 20);
            endSelectedMenuItem.Text = "End Selected";
            endSelectedMenuItem.Visible = false;
            endSelectedMenuItem.Click += EndSelected_Click;
            // 
            // endAllMenuItem
            // 
            endAllMenuItem.Name = "endAllMenuItem";
            endAllMenuItem.Size = new System.Drawing.Size(56, 20);
            endAllMenuItem.Text = "End All";
            endAllMenuItem.Click += EndAll_Click;
            // 
            // untickAllMenuItem
            // 
            untickAllMenuItem.Name = "untickAllMenuItem";
            untickAllMenuItem.Size = new System.Drawing.Size(70, 20);
            untickAllMenuItem.Text = "Untick All";
            untickAllMenuItem.Click += UntickAll_Click;
            // 
            // resizeAllMenuItem
            // 
            resizeAllMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resizeAllMenuItem.Name = "resizeAllMenuItem";
            resizeAllMenuItem.Size = new System.Drawing.Size(68, 20);
            resizeAllMenuItem.Text = "Resize All";
            resizeAllMenuItem.Click += ResizeAll_Click;
            // 
            // LoginButton
            // 
            LoginButton.Location = new System.Drawing.Point(14, 327);
            LoginButton.Margin = new Padding(4, 3, 4, 3);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new System.Drawing.Size(600, 29);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "Play";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // accountGrid
            // 
            accountGrid.AllowDrop = true;
            accountGrid.AllowUserToResizeColumns = false;
            accountGrid.AllowUserToResizeRows = false;
            accountGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            accountGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountGrid.Columns.AddRange(new DataGridViewColumn[] { Login, Toon, ToonSlots, End });
            accountGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            accountGrid.Location = new System.Drawing.Point(14, 31);
            accountGrid.Margin = new Padding(4, 3, 4, 3);
            accountGrid.Name = "accountGrid";
            accountGrid.ScrollBars = ScrollBars.Vertical;
            accountGrid.ShowCellToolTips = false;
            accountGrid.Size = new System.Drawing.Size(600, 288);
            accountGrid.TabIndex = 3;
            accountGrid.CellMouseUp += AccGrid_OnCellMouseUp;
            accountGrid.CellValueChanged += AccGrid_CellValueChanged;
            accountGrid.DataBindingComplete += AccGrid_DataBindingComplete;
            accountGrid.UserDeletingRow += AccGrid_UserDeletingRow;
            accountGrid.DragDrop += AccGrid_DragDrop;
            // 
            // Login
            // 
            Login.DataPropertyName = "LoginWanted";
            Login.HeaderText = "Login?";
            Login.Name = "Login";
            Login.Width = 50;
            // 
            // Toon
            // 
            Toon.DataPropertyName = "Toon";
            Toon.HeaderText = "Toon";
            Toon.Name = "Toon";
            Toon.ReadOnly = true;
            // 
            // ToonSlots
            // 
            ToonSlots.HeaderText = "Jump to";
            ToonSlots.Name = "ToonSlots";
            ToonSlots.Width = 125;
            // 
            // End
            // 
            End.DataPropertyName = "EndWanted";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            End.DefaultCellStyle = dataGridViewCellStyle1;
            End.HeaderText = "End?";
            End.Name = "End";
            End.ReadOnly = true;
            End.Width = 50;
            // 
            // Launcher
            // 
            AcceptButton = LoginButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(623, 362);
            Controls.Add(accountGrid);
            Controls.Add(LoginButton);
            Controls.Add(TopMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = TopMenu;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tunetoon";
            Load += Launcher_Load;
            Shown += Launcher_Shown;
            TopMenu.ResumeLayout(false);
            TopMenu.PerformLayout();
            ServerMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)accountGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
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