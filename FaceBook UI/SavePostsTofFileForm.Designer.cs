namespace A19_Ex1_Nir_0_Nir_0
{
    partial class SavePostsTofFileForm
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
            this.textBoxFileTitle = new System.Windows.Forms.TextBox();
            this.comboBoxTyps = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreateFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // textBoxFileTitle
            // 
            this.textBoxFileTitle.Location = new System.Drawing.Point(84, 28);
            this.textBoxFileTitle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFileTitle.Name = "textBoxFileTitle";
            this.textBoxFileTitle.Size = new System.Drawing.Size(115, 20);
            this.textBoxFileTitle.TabIndex = 1;
            // 
            // comboBoxTyps
            // 
            this.comboBoxTyps.FormattingEnabled = true;
            this.comboBoxTyps.Items.AddRange(new object[] {
            "XML",
            "JSON",
            "Text File"});
            this.comboBoxTyps.Location = new System.Drawing.Point(84, 63);
            this.comboBoxTyps.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTyps.Name = "comboBoxTyps";
            this.comboBoxTyps.Size = new System.Drawing.Size(82, 21);
            this.comboBoxTyps.TabIndex = 2;
            this.comboBoxTyps.SelectedIndexChanged += new System.EventHandler(this.comboBoxTyps_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type Of File";
            // 
            // buttonCreateFile
            // 
            this.buttonCreateFile.Location = new System.Drawing.Point(269, 135);
            this.buttonCreateFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreateFile.Name = "buttonCreateFile";
            this.buttonCreateFile.Size = new System.Drawing.Size(93, 56);
            this.buttonCreateFile.TabIndex = 4;
            this.buttonCreateFile.Text = "Create File";
            this.buttonCreateFile.UseVisualStyleBackColor = true;
            this.buttonCreateFile.Click += new System.EventHandler(this.buttonCreateFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Save To";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(82, 97);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(201, 20);
            this.textBoxPath.TabIndex = 5;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBrowse.Location = new System.Drawing.Point(301, 88);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(61, 29);
            this.buttonBrowse.TabIndex = 7;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = false;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // SavePostsTofFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(370, 197);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonCreateFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTyps);
            this.Controls.Add(this.textBoxFileTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SavePostsTofFileForm";
            this.Text = "Save To File";
            this.Load += new System.EventHandler(this.SaveTofFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileTitle;
        private System.Windows.Forms.ComboBox comboBoxTyps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreateFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonBrowse;
    }
}