namespace WinFormUI
{
    partial class TopWordsFeature
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
            this.listboxTotalPosts = new System.Windows.Forms.ListBox();
            this.listBoxTopWords = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSumTot = new System.Windows.Forms.Label();
            this.textBoxWordToAnalysis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonLikes = new System.Windows.Forms.RadioButton();
            this.radioButtonAlphabetical = new System.Windows.Forms.RadioButton();
            this.radioButtonRecent = new System.Windows.Forms.RadioButton();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxTotalPosts
            // 
            this.listboxTotalPosts.FormattingEnabled = true;
            this.listboxTotalPosts.Location = new System.Drawing.Point(8, 42);
            this.listboxTotalPosts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listboxTotalPosts.Name = "listboxTotalPosts";
            this.listboxTotalPosts.Size = new System.Drawing.Size(207, 199);
            this.listboxTotalPosts.TabIndex = 0;
            // 
            // listBoxTopWords
            // 
            this.listBoxTopWords.FormattingEnabled = true;
            this.listBoxTopWords.Location = new System.Drawing.Point(218, 42);
            this.listBoxTopWords.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxTopWords.Name = "listBoxTopWords";
            this.listBoxTopWords.Size = new System.Drawing.Size(109, 199);
            this.listBoxTopWords.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 297);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Posts:";
            // 
            // labelSumTot
            // 
            this.labelSumTot.AutoSize = true;
            this.labelSumTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSumTot.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelSumTot.Location = new System.Drawing.Point(72, 297);
            this.labelSumTot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSumTot.Name = "labelSumTot";
            this.labelSumTot.Size = new System.Drawing.Size(15, 13);
            this.labelSumTot.TabIndex = 4;
            this.labelSumTot.Text = "--";
            // 
            // textBoxWordToAnalysis
            // 
            this.textBoxWordToAnalysis.Location = new System.Drawing.Point(8, 21);
            this.textBoxWordToAnalysis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxWordToAnalysis.Name = "textBoxWordToAnalysis";
            this.textBoxWordToAnalysis.Size = new System.Drawing.Size(129, 20);
            this.textBoxWordToAnalysis.TabIndex = 7;
            this.textBoxWordToAnalysis.TextChanged += new System.EventHandler(this.textBoxWordToAnalysis_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.YellowGreen;
            this.label2.Location = new System.Drawing.Point(220, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Top Words:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "(Double click on status to show full details)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonLikes);
            this.groupBox1.Controls.Add(this.radioButtonAlphabetical);
            this.groupBox1.Controls.Add(this.radioButtonRecent);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 244);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(315, 47);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By";
            // 
            // radioButtonLikes
            // 
            this.radioButtonLikes.AutoSize = true;
            this.radioButtonLikes.Location = new System.Drawing.Point(146, 16);
            this.radioButtonLikes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonLikes.Name = "radioButtonLikes";
            this.radioButtonLikes.Size = new System.Drawing.Size(50, 17);
            this.radioButtonLikes.TabIndex = 2;
            this.radioButtonLikes.TabStop = true;
            this.radioButtonLikes.Text = "Likes";
            this.radioButtonLikes.UseVisualStyleBackColor = true;
            // 
            // radioButtonAlphabetical
            // 
            this.radioButtonAlphabetical.AutoSize = true;
            this.radioButtonAlphabetical.Location = new System.Drawing.Point(63, 17);
            this.radioButtonAlphabetical.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonAlphabetical.Name = "radioButtonAlphabetical";
            this.radioButtonAlphabetical.Size = new System.Drawing.Size(83, 17);
            this.radioButtonAlphabetical.TabIndex = 1;
            this.radioButtonAlphabetical.TabStop = true;
            this.radioButtonAlphabetical.Text = "Alphabetical";
            this.radioButtonAlphabetical.UseVisualStyleBackColor = true;
            // 
            // radioButtonRecent
            // 
            this.radioButtonRecent.AutoSize = true;
            this.radioButtonRecent.Location = new System.Drawing.Point(5, 17);
            this.radioButtonRecent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonRecent.Name = "radioButtonRecent";
            this.radioButtonRecent.Size = new System.Drawing.Size(60, 17);
            this.radioButtonRecent.TabIndex = 0;
            this.radioButtonRecent.TabStop = true;
            this.radioButtonRecent.Text = "Recent";
            this.radioButtonRecent.UseVisualStyleBackColor = true;
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(75, 345);
            this.buttonSaveToFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(171, 49);
            this.buttonSaveToFile.TabIndex = 11;
            this.buttonSaveToFile.Text = "Save To File";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // TopWordsFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 421);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWordToAnalysis);
            this.Controls.Add(this.labelSumTot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxTopWords);
            this.Controls.Add(this.listboxTotalPosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopWordsFeature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TopWords";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxTotalPosts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSumTot;
        private System.Windows.Forms.TextBox textBoxWordToAnalysis;
        private System.Windows.Forms.ListBox listBoxTopWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonLikes;
        private System.Windows.Forms.RadioButton radioButtonAlphabetical;
        private System.Windows.Forms.RadioButton radioButtonRecent;
        private System.Windows.Forms.Button buttonSaveToFile;
    }
}