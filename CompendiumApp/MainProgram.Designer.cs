namespace CompendiumApp
{
    partial class MainProgram
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
            this.questionString = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicString = new System.Windows.Forms.Label();
            this.differentTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionString
            // 
            this.questionString.AutoSize = true;
            this.questionString.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionString.Location = new System.Drawing.Point(26, 88);
            this.questionString.MaximumSize = new System.Drawing.Size(750, 0);
            this.questionString.Name = "questionString";
            this.questionString.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.questionString.Size = new System.Drawing.Size(156, 29);
            this.questionString.TabIndex = 0;
            this.questionString.Text = "questionString";
            this.questionString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answerBox
            // 
            this.answerBox.Font = new System.Drawing.Font("Calibri", 18F);
            this.answerBox.Location = new System.Drawing.Point(72, 329);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(451, 37);
            this.answerBox.TabIndex = 1;
            this.answerBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnswerBoxEnter);
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Calibri", 18F);
            this.submitButton.Location = new System.Drawing.Point(552, 328);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(190, 37);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.newToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.differentTermToolStripMenuItem,
            this.toolStripMenuItem1,
            this.restartToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.filesToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cheToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // cheToolStripMenuItem
            // 
            this.cheToolStripMenuItem.Name = "cheToolStripMenuItem";
            this.cheToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.cheToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cheToolStripMenuItem.Text = "Show answer";
            this.cheToolStripMenuItem.Click += new System.EventHandler(this.CheToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTermToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            // 
            // newTermToolStripMenuItem
            // 
            this.newTermToolStripMenuItem.Name = "newTermToolStripMenuItem";
            this.newTermToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newTermToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTermToolStripMenuItem.Text = "New Term";
            this.newTermToolStripMenuItem.Click += new System.EventHandler(this.NewTermToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTermToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editTermToolStripMenuItem
            // 
            this.editTermToolStripMenuItem.Name = "editTermToolStripMenuItem";
            this.editTermToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editTermToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editTermToolStripMenuItem.Text = "Edit Term";
            this.editTermToolStripMenuItem.Click += new System.EventHandler(this.EditTermToolStripMenuItem_Click);
            // 
            // topicString
            // 
            this.topicString.AutoSize = true;
            this.topicString.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.topicString.Location = new System.Drawing.Point(12, 24);
            this.topicString.Name = "topicString";
            this.topicString.Size = new System.Drawing.Size(74, 18);
            this.topicString.TabIndex = 4;
            this.topicString.Text = "topicString";
            // 
            // differentTermToolStripMenuItem
            // 
            this.differentTermToolStripMenuItem.Name = "differentTermToolStripMenuItem";
            this.differentTermToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.differentTermToolStripMenuItem.Text = "Different Term";
            this.differentTermToolStripMenuItem.Click += new System.EventHandler(this.DifferentTermToolStripMenuItem_Click);
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.topicString);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.questionString);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainProgram";
            this.Text = "Compendium App";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionString;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.Label topicString;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTermToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTermToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differentTermToolStripMenuItem;
    }
}

