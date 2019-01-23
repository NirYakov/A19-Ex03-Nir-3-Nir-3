using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FB_Logic;

namespace WinFormUI
{
    public partial class FormPostSummary : Form
    {
        public Post ThePost { get; set; }

        public FormPostSummary(Post i_ThePost)
        {
            ThePost = i_ThePost;
            InitializeComponent();
            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;
            themeColorEvent.ThemeChanged += themeColor_ChangedTheme;
            themeColor_ChangedTheme(themeColorEvent.BackColor, themeColorEvent.ForeColor);
        }

        private void themeColor_ChangedTheme(Color i_BackColor, Color i_ForeColor)
        {
            lableStatus.BackColor = i_BackColor;
            lableStatus.ForeColor = i_ForeColor;
        }

        private void FormPostSummary_Load(object sender, EventArgs e)
        {
            lableStatus.Text = ThePost.Message;

            foreach (Comment comment in ThePost.Comments)
            {
                listBoxComments.Items.Add(comment.ToString());
            }

            labelNumOfLikes.Text = ThePost.LikedBy.Count.ToString();
            dateTimePicker1.Value = new DateTime(ThePost.UpdateTime.Value.Ticks);
        }

        private void linkToPostOnFB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(ThePost.Link);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
