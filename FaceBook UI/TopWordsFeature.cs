using System;
using System.Collections.Generic;
using System.Linq;
using FB_Logic;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormUI
{
    public partial class TopWordsFeature : Form
    {
        private readonly ProxyPostAnalisys r_PostAnalysis;

        public TopWordsFeature(List<Post> offlinePostsList)
        {
            InitializeComponent();
            InitializeCustomeComponent();
            r_PostAnalysis = new ProxyPostAnalisys(offlinePostsList);
            updateListBoxPosts();
            populateListBoxTopWords();
        }

        private void updateListBoxPosts()
        {
            listBoxTopWords.DisplayMember = "Message";
            labelSumTot.Text = listboxTotalPosts.Items.Count.ToString();
        }

        private void InitializeCustomeComponent()
        {
            listboxTotalPosts.MouseDoubleClick += new MouseEventHandler(listboxTotalPosts_MouseDoubleClick);
            listBoxTopWords.SelectedIndexChanged += ListBoxTopWords_SelectedIndexChanged;
            radioButtonAlphabetical.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioButtonLikes.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioButtonRecent.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;
            themeColorEvent.ThemeChanged += ThemeColorChanged;
            ThemeColorChanged(themeColorEvent.BackColor, themeColorEvent.ForeColor);

        }

        private void ThemeColorChanged(Color i_BackColor, Color i_ForeColor)
        {
            radioButtonRecent.ForeColor = i_ForeColor;
            radioButtonAlphabetical.ForeColor = i_ForeColor;
            radioButtonLikes.ForeColor = i_ForeColor;
            groupBox1.BackColor = i_BackColor;
            groupBox1.ForeColor = i_ForeColor;
        }

        private void ListBoxTopWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stringToSearch = listBoxTopWords.GetItemText(listBoxTopWords.SelectedItem);
            textBoxWordToAnalysis.Text = stringToSearch;
        }

        private void populateListBoxTopWords()
        {
            listBoxTopWords.Items.Clear();
            Dictionary<string, int> topWords = r_PostAnalysis.GetTopKWords();
            listBoxTopWords.DataSource = new BindingSource(topWords, null);
            listBoxTopWords.DisplayMember = "Key";
            listBoxTopWords.ValueMember = "Value";
        }

        private void textBoxWordToAnalysis_TextChanged(object sender, EventArgs e)
        {
            string wordToAnalysis = textBoxWordToAnalysis.Text;
            listboxTotalPosts.DataSource = new BindingSource(r_PostAnalysis.GetPostsByWord(wordToAnalysis), null);
            listboxTotalPosts.DisplayMember = "Message";
            labelSumTot.Text = listboxTotalPosts.Items.Count.ToString();
            radioButtons_CheckedChanged(null, null);
        }

        private void listboxTotalPosts_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (listboxTotalPosts.SelectedItem != null)
            {
                FormPostSummary formPostSummary = new FormPostSummary((Post)listboxTotalPosts.SelectedItem);
                formPostSummary.ShowDialog();
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            string sortMethod = String.Empty;
            List<Post> listToSort = listboxTotalPosts.Items.OfType<Post>().ToList();

            if (radioButtonAlphabetical.Checked)
            {
                sortMethod = radioButtonAlphabetical.Text;
            }
            else if (radioButtonLikes.Checked)
            {
                sortMethod = radioButtonLikes.Text;
            }
            else
            {
                sortMethod = radioButtonRecent.Text;
            }

            listboxTotalPosts.DataSource = r_PostAnalysis.SortByParameter(sortMethod, listToSort);
            
        }
    }
}