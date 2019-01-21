using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace A19_Ex1_Nir_0_Nir_0
{
    public partial class SavePostsTofFileForm : Form
    {
        public SavePostsTofFileForm(List<Post> i_ListOfPosts)
        {
            InitializeComponent();
        }

        private void SaveTofFileForm_Load(object sender, EventArgs e)
        {
            textBoxFileTitle.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        ;
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

        }
    }
}
