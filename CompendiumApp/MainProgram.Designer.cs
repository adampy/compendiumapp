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
            this.hiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.questionString.Size = new System.Drawing.Size(741, 58);
            this.questionString.TabIndex = 0;
            this.questionString.Text = "questionStringquestionStringquestionStringquestionStringquestionStringquestionStr" +
    "ingquestionStringquestionStringquestionStringquestionString";
            this.questionString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answerBox
            // 
            this.answerBox.Font = new System.Drawing.Font("Calibri", 18F);
            this.answerBox.Location = new System.Drawing.Point(72, 329);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(451, 37);
            this.answerBox.TabIndex = 1;
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
            this.filesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // hiToolStripMenuItem
            // 
            this.hiToolStripMenuItem.Name = "hiToolStripMenuItem";
            this.hiToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.hiToolStripMenuItem.Text = "Hi";
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.ToolStripMenuItem hiToolStripMenuItem;
    }
}

