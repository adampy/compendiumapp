namespace CompendiumApp
{
    partial class NewTerm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.topicComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.termInputBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.createTerm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.termId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Term";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Topic";
            // 
            // topicComboBox
            // 
            this.topicComboBox.Enabled = false;
            this.topicComboBox.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicComboBox.FormattingEnabled = true;
            this.topicComboBox.Location = new System.Drawing.Point(93, 60);
            this.topicComboBox.Name = "topicComboBox";
            this.topicComboBox.Size = new System.Drawing.Size(569, 44);
            this.topicComboBox.TabIndex = 3;
            this.topicComboBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 21.75F);
            this.textBox1.Location = new System.Drawing.Point(18, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(644, 184);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Term";
            // 
            // termInputBox
            // 
            this.termInputBox.Font = new System.Drawing.Font("Calibri", 21.75F);
            this.termInputBox.Location = new System.Drawing.Point(91, 395);
            this.termInputBox.Name = "termInputBox";
            this.termInputBox.Size = new System.Drawing.Size(318, 43);
            this.termInputBox.TabIndex = 7;
            this.termInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TermInputPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 21.75F);
            this.button1.Location = new System.Drawing.Point(417, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add term";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddTermClick);
            // 
            // createTerm
            // 
            this.createTerm.Font = new System.Drawing.Font("Calibri", 21.75F);
            this.createTerm.Location = new System.Drawing.Point(560, 395);
            this.createTerm.Name = "createTerm";
            this.createTerm.Size = new System.Drawing.Size(103, 43);
            this.createTerm.TabIndex = 9;
            this.createTerm.Text = "Create";
            this.createTerm.UseVisualStyleBackColor = true;
            this.createTerm.Click += new System.EventHandler(this.CreateTerm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 316);
            this.label3.MaximumSize = new System.Drawing.Size(200, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 76);
            this.label3.TabIndex = 10;
            this.label3.Text = "Acceptable answers - press add term to add multiple correct answers (click to rem" +
    "ove the term)";
            // 
            // termId
            // 
            this.termId.AutoSize = true;
            this.termId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termId.ForeColor = System.Drawing.Color.Black;
            this.termId.Location = new System.Drawing.Point(12, 9);
            this.termId.MaximumSize = new System.Drawing.Size(200, 0);
            this.termId.Name = "termId";
            this.termId.Size = new System.Drawing.Size(51, 19);
            this.termId.TabIndex = 11;
            this.termId.Text = "termId";
            // 
            // NewTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 447);
            this.Controls.Add(this.termId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.createTerm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.termInputBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.topicComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewTerm";
            this.Text = "New Term";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox topicComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox termInputBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createTerm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label termId;
    }
}