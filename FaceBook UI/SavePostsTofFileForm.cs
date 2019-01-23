using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FB_Logic;
using FB_Logic.PostToFileClasses;

namespace A19_Ex1_Nir_0_Nir_0
{
    public partial class SavePostsTofFileForm : Form
    {
        private readonly List<Post> r_ListOfPosts;
        public SavePostsTofFileForm(List<Post> i_ListOfPosts)
        {
            InitializeComponent();
            r_ListOfPosts = i_ListOfPosts;
        }

        private void SaveTofFileForm_Load(object sender, EventArgs e)
        {
            textBoxFileTitle.Text = String.Format("My Posts {0}", DateTime.Now.ToString("yy-MM-dd"));
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = fbd.SelectedPath;
            }
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text == string.Empty || comboBoxTyps.Text == string.Empty ||
                textBoxFileTitle.Text == string.Empty)
            {
                MessageBox.Show("Invalid values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (comboBoxTyps.Text == "Text File")
                    {
                        new SimpleTextFileGenertor(r_ListOfPosts, textBoxFileTitle.Text, textBoxPath.Text);
                    }

                    if (comboBoxTyps.Text == "XML")
                    {
                        new XmlFileGenerator(r_ListOfPosts, textBoxFileTitle.Text, textBoxPath.Text);
                    }

                    if (comboBoxTyps.Text == "JSON")
                    {
                        new JsonFileGenerator(r_ListOfPosts, textBoxFileTitle.Text, textBoxPath.Text);
                    }

                    MessageBox.Show("File has been saved");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (DirectoryNotFoundException )
                {
                    MessageBox.Show("Invalid path");
                }
            }
        }
    }
}
