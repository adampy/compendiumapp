namespace CompendiumApp
{
    partial class TopicSelect
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
            this.button1 = new System.Windows.Forms.Button();
            this.topicBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.csDefsDataSet1 = new CompendiumApp.CSDefsDataSet();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.csDefsDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(110, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "CS Compendium App";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 18F);
            this.button1.Location = new System.Drawing.Point(264, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // topicBox
            // 
            this.topicBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicBox.FormattingEnabled = true;
            this.topicBox.Location = new System.Drawing.Point(47, 150);
            this.topicBox.Name = "topicBox";
            this.topicBox.Size = new System.Drawing.Size(462, 31);
            this.topicBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(125, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "by Adam Crawley";
            this.label2.Visible = false;
            // 
            // csDefsDataSet1
            // 
            this.csDefsDataSet1.DataSetName = "CSDefsDataSet";
            this.csDefsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 18F);
            this.button2.Location = new System.Drawing.Point(47, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "Make a new topic";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TopicSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 282);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topicBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "TopicSelect";
            this.Text = "Topic Selector";
            ((System.ComponentModel.ISupportInitialize)(this.csDefsDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox topicBox;
        private System.Windows.Forms.Label label2;
        private CSDefsDataSet csDefsDataSet1;
        private System.Windows.Forms.Button button2;
    }
}