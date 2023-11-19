namespace Tunetoon.Forms
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            OkayButton = new System.Windows.Forms.Button();
            RewrittenLabel = new System.Windows.Forms.Label();
            ClashLabel = new System.Windows.Forms.Label();
            SelectionCheckBox = new System.Windows.Forms.CheckBox();
            GlobalEndCheckBox = new System.Windows.Forms.CheckBox();
            RewrittenPath = new System.Windows.Forms.TextBox();
            ClashPath = new System.Windows.Forms.TextBox();
            RewrittenPathButton = new System.Windows.Forms.Button();
            ClashPathButton = new System.Windows.Forms.Button();
            SkipUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            EncryptAccsCheckBox = new System.Windows.Forms.CheckBox();
            OpenAccountsInRowsCheckbox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // OkayButton
            // 
            OkayButton.Location = new System.Drawing.Point(14, 229);
            OkayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OkayButton.Name = "OkayButton";
            OkayButton.Size = new System.Drawing.Size(564, 27);
            OkayButton.TabIndex = 0;
            OkayButton.Text = "Save";
            OkayButton.UseVisualStyleBackColor = true;
            OkayButton.Click += OkayButton_Click;
            // 
            // RewrittenLabel
            // 
            RewrittenLabel.AutoSize = true;
            RewrittenLabel.Location = new System.Drawing.Point(10, 16);
            RewrittenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            RewrittenLabel.Name = "RewrittenLabel";
            RewrittenLabel.Size = new System.Drawing.Size(87, 15);
            RewrittenLabel.TabIndex = 3;
            RewrittenLabel.Text = "Rewritten Path:";
            // 
            // ClashLabel
            // 
            ClashLabel.AutoSize = true;
            ClashLabel.Location = new System.Drawing.Point(10, 74);
            ClashLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ClashLabel.Name = "ClashLabel";
            ClashLabel.Size = new System.Drawing.Size(66, 15);
            ClashLabel.TabIndex = 4;
            ClashLabel.Text = "Clash Path:";
            // 
            // SelectionCheckBox
            // 
            SelectionCheckBox.AutoSize = true;
            SelectionCheckBox.Location = new System.Drawing.Point(398, 136);
            SelectionCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SelectionCheckBox.Name = "SelectionCheckBox";
            SelectionCheckBox.Size = new System.Drawing.Size(112, 19);
            SelectionCheckBox.TabIndex = 5;
            SelectionCheckBox.Text = "End by selection";
            SelectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // GlobalEndCheckBox
            // 
            GlobalEndCheckBox.AutoSize = true;
            GlobalEndCheckBox.Location = new System.Drawing.Point(398, 163);
            GlobalEndCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            GlobalEndCheckBox.Name = "GlobalEndCheckBox";
            GlobalEndCheckBox.Size = new System.Drawing.Size(175, 19);
            GlobalEndCheckBox.TabIndex = 6;
            GlobalEndCheckBox.Text = "\"End All\" for all gameservers";
            GlobalEndCheckBox.UseVisualStyleBackColor = true;
            // 
            // RewrittenPath
            // 
            RewrittenPath.Location = new System.Drawing.Point(14, 35);
            RewrittenPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RewrittenPath.Name = "RewrittenPath";
            RewrittenPath.Size = new System.Drawing.Size(517, 23);
            RewrittenPath.TabIndex = 9;
            // 
            // ClashPath
            // 
            ClashPath.Location = new System.Drawing.Point(14, 92);
            ClashPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ClashPath.Name = "ClashPath";
            ClashPath.Size = new System.Drawing.Size(517, 23);
            ClashPath.TabIndex = 10;
            // 
            // RewrittenPathButton
            // 
            RewrittenPathButton.Location = new System.Drawing.Point(539, 35);
            RewrittenPathButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RewrittenPathButton.Name = "RewrittenPathButton";
            RewrittenPathButton.Size = new System.Drawing.Size(38, 23);
            RewrittenPathButton.TabIndex = 11;
            RewrittenPathButton.Text = "...";
            RewrittenPathButton.UseVisualStyleBackColor = true;
            RewrittenPathButton.Click += RewrittenPathButton_Click;
            // 
            // ClashPathButton
            // 
            ClashPathButton.Location = new System.Drawing.Point(539, 92);
            ClashPathButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ClashPathButton.Name = "ClashPathButton";
            ClashPathButton.Size = new System.Drawing.Size(38, 24);
            ClashPathButton.TabIndex = 12;
            ClashPathButton.Text = "...";
            ClashPathButton.UseVisualStyleBackColor = true;
            ClashPathButton.Click += ClashPathButton_Click;
            // 
            // SkipUpdatesCheckBox
            // 
            SkipUpdatesCheckBox.AutoSize = true;
            SkipUpdatesCheckBox.Location = new System.Drawing.Point(18, 136);
            SkipUpdatesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SkipUpdatesCheckBox.Name = "SkipUpdatesCheckBox";
            SkipUpdatesCheckBox.Size = new System.Drawing.Size(126, 19);
            SkipUpdatesCheckBox.TabIndex = 14;
            SkipUpdatesCheckBox.Text = "Skip game updates";
            SkipUpdatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptAccsCheckBox
            // 
            EncryptAccsCheckBox.AutoSize = true;
            EncryptAccsCheckBox.Location = new System.Drawing.Point(18, 163);
            EncryptAccsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EncryptAccsCheckBox.Name = "EncryptAccsCheckBox";
            EncryptAccsCheckBox.Size = new System.Drawing.Size(117, 19);
            EncryptAccsCheckBox.TabIndex = 17;
            EncryptAccsCheckBox.Text = "Encrypt accounts";
            EncryptAccsCheckBox.UseVisualStyleBackColor = true;
            EncryptAccsCheckBox.CheckedChanged += EncryptAccsCheckBox_CheckedChanged;
            // 
            // OpenAccountsInRowsCheckbox
            // 
            OpenAccountsInRowsCheckbox.AutoSize = true;
            OpenAccountsInRowsCheckbox.Location = new System.Drawing.Point(18, 191);
            OpenAccountsInRowsCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OpenAccountsInRowsCheckbox.Name = "OpenAccountsInRowsCheckbox";
            OpenAccountsInRowsCheckbox.Size = new System.Drawing.Size(147, 19);
            OpenAccountsInRowsCheckbox.TabIndex = 18;
            OpenAccountsInRowsCheckbox.Text = "Open accounts in rows";
            OpenAccountsInRowsCheckbox.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(593, 268);
            Controls.Add(OpenAccountsInRowsCheckbox);
            Controls.Add(EncryptAccsCheckBox);
            Controls.Add(SkipUpdatesCheckBox);
            Controls.Add(ClashPathButton);
            Controls.Add(RewrittenPathButton);
            Controls.Add(ClashPath);
            Controls.Add(RewrittenPath);
            Controls.Add(GlobalEndCheckBox);
            Controls.Add(SelectionCheckBox);
            Controls.Add(ClashLabel);
            Controls.Add(RewrittenLabel);
            Controls.Add(OkayButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Options";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Options";
            Load += Options_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label RewrittenLabel;
        private System.Windows.Forms.Label ClashLabel;
        private System.Windows.Forms.CheckBox SelectionCheckBox;
        private System.Windows.Forms.CheckBox GlobalEndCheckBox;
        private System.Windows.Forms.TextBox RewrittenPath;
        private System.Windows.Forms.TextBox ClashPath;
        private System.Windows.Forms.Button RewrittenPathButton;
        private System.Windows.Forms.Button ClashPathButton;
        private System.Windows.Forms.CheckBox SkipUpdatesCheckBox;
        private System.Windows.Forms.CheckBox EncryptAccsCheckBox;
        private System.Windows.Forms.CheckBox OpenAccountsInRowsCheckbox;
    }
}