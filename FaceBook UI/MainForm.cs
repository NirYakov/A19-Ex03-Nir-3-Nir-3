using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FB_Logic;
using FacebookWrapper.ObjectModel;

namespace WinFormUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            initSettings();
        }

        private void initSettings()
        {
            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;

            themeColorEvent.ThemeChanged += themeColor_ChangedTheme;

            themeColorEvent.ChangeTheme(Color.CornflowerBlue, Color.White);

            timerUsage.Start();
        }

        private void themeColor_ChangedTheme(Color i_BackColor, Color i_ForeColor)
        {
            panelData.BackColor = i_BackColor;
            labelFriendsStatus.ForeColor = i_ForeColor;
            labelFriendsNum.ForeColor = i_ForeColor;
            labelPostsStatus.ForeColor = i_ForeColor;
            labelPostsNum.ForeColor = i_ForeColor;
            labelLikedPagesStatus.ForeColor = i_ForeColor;
            labelLikedPagesNum.ForeColor = i_ForeColor;
            labelCheckinsStatus.ForeColor = i_ForeColor;
            labelCheckinsNum.ForeColor = i_ForeColor;
            labelEventsStatus.ForeColor = i_ForeColor;
            labelEventsNum.ForeColor = i_ForeColor;

            btnLogin.BackColor = i_BackColor;
            btnLogin.ForeColor = i_ForeColor;

            checkBoxInvertColors.BackColor = i_ForeColor;
            checkBoxInvertColors.ForeColor = i_BackColor;

            btnFeature1.BackColor = i_BackColor;
            btnFeature1.ForeColor = i_ForeColor;
            btnFeature2.BackColor = i_BackColor;
            btnFeature2.ForeColor = i_ForeColor;
        }

        private void InitializationAfterLogIn()
        {
            timerUsage.Stop();
            btnFeature1.Enabled = true;
            btnFeature2.Enabled = true;
            linkFriends.Enabled = true;
            listBoxFriends.Enabled = true;
            pictureBoxFriend.Enabled = true;
            textBoxPost.Enabled = true;
            btnPost.Enabled = true;
            linkPosts.Enabled = true;
            listBoxPosts.Enabled = true;
            linkPages.Enabled = true;
            listBoxPages.Enabled = true;
            linkCheckins.Enabled = true;
            listBoxCheckins.Enabled = true;
            labelEvents.Enabled = true;
            listBoxEvents.Enabled = true;
            panelActive.BackColor = Color.Chartreuse;
            btnLogin.Visible = false;
            pictureBoxLogOut.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserManager.Login();
                this.Text = UserManager.UserName;
                InitializationAfterLogIn();
                pictureBoxUser.LoadAsync(UserManager.UserPictureUrl);
                pictureBoxCoverPic.LoadAsync(UserManager.UserPictureUrlCover);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkFriends_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(fetchFriends).Start();
        }

        private void fetchFriends()
        {
            var allFriends = UserManager.User.Friends;

            if (!listBoxFriends.InvokeRequired)
            {
                userBindingSource.DataSource = allFriends;
            }
            else
            {
                listBoxFriends.Invoke(new Action(() => userBindingSource.DataSource = allFriends));
            }
        }

        private void linkPosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchPosts();
        }

        private void fetchPosts()
        {
            foreach (Post post in UserManager.User.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Items.Add(post.Caption);
                }
                else
                {
                    listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            int postsNum = UserManager.User.Posts.Count;
            if (postsNum == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
            else
            {
                labelPostsNum.Text = postsNum.ToString();
            }
        }

        private List<Post> getPostsList()
        {
            List<Post> PostsList = new List<Post>();
            foreach (Post post in UserManager.User.Posts)
            {
                if (post.Message != null)
                {
                    PostsList.Add(post);
                }
            }

            return PostsList;
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriend();
        }

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = listBoxFriends.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBoxFriend.LoadAsync(selectedFriend.PictureNormalURL);
                }
                else
                {
                    pictureBoxFriend.Image = pictureBoxFriend.ErrorImage;
                }
            }
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            UserManager.UserLogOut();
            timerUsage.Stop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                UserManager.User.PostStatus(textBoxPost.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(
@"Can't post status right now,
Back later . :(");
            }
        }

        private void labelEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchEvents();
        }

        private void fetchEvents()
        {
            try
            {
                var allEvents = UserManager.User.Events;

                if (!listBoxFriends.InvokeRequired)
                {
                    eventBindingSource.DataSource = allEvents;
                }
                else
                {
                    listBoxFriends.Invoke((new Action(() => eventBindingSource.DataSource = allEvents)));
                }
            }
            catch (Exception)
            {
                ErrorMessage("Events");
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItems.Count == 1)
            {
                if (listBoxEvents.SelectedItems.Count == 1)
                {
                    Event selectedEvent = listBoxEvents.SelectedItem as Event;
                    pictureBoxEvent.LoadAsync(selectedEvent.PictureNormalURL);
                }
            }
        }

        private void linkCheckins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchCheckins();
        }

        private void fetchCheckins()
        {
            try
            {
                foreach (Checkin checkin in UserManager.User.Checkins)
                {
                    listBoxCheckins.Items.Add(checkin.Place.Name);
                }

                labelCheckinsNum.Text = UserManager.User.Checkins.Count.ToString();
                if (UserManager.User.Checkins.Count == 0)
                {
                    MessageBox.Show("No Checkins to retrieve :(");
                }
            }
            catch (Exception)
            {
                ErrorMessage("Checkins");
            }
        }

        private void linkPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchPages();
        }

        private void fetchPages()
        {
            try
            {
                listBoxPages.Items.Clear();
                listBoxPages.DisplayMember = "Name";

                foreach (Page page in UserManager.User.LikedPages)
                {
                    listBoxPages.Items.Add(page);
                }

                labelLikedPagesNum.Text = UserManager.User.LikedPages.Count.ToString();
                if (UserManager.User.LikedPages.Count == 0)
                {
                    MessageBox.Show("No liked pages to retrieve :(");
                }
            }
            catch (Exception)
            {
                ErrorMessage("Liked Pages");
            }
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedItems.Count == 1)
            {
                Page selectedPage = listBoxPages.SelectedItem as Page;
                pictureBoxPage.LoadAsync(selectedPage.PictureNormalURL);
            }
        }

        private void ErrorMessage(string i_ErrorSource)
        {
            MessageBox.Show(
@"Error occurred in {0}
Plase try later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFeature2_Click(object sender, EventArgs e)
        {
            List<Post> postsList = getPostsList();
            TopWordsFeature featureTwo = new TopWordsFeature(postsList);
            featureTwo.ShowDialog();
        }

        private void btnFeature1_Click(object sender, EventArgs e)
        {
            this.Hide();

            new UsersValue().Show();

            this.Show();
        }

        private void timerUsage_Tick(object sender, EventArgs e)
        {
            Color color = btnLogin.BackColor;
            btnLogin.BackColor = btnLogin.ForeColor;
            btnLogin.ForeColor = color;
        }

        private void radioButtonThemeColor_CheckedChanged(object sender, EventArgs e)
        {
            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;
            Color colorBack, colorFore;
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                if (checkBoxInvertColors.Checked)
                {
                    colorBack = radioButton.ForeColor;
                    colorFore = radioButton.BackColor;
                }
                else
                {
                    colorBack = radioButton.BackColor;
                    colorFore = radioButton.ForeColor;
                }
            }
            else
            {
                colorBack = Color.CornflowerBlue;
                colorFore = Color.White;
            }

            themeColorEvent.ChangeTheme(colorBack, colorFore);
        }

        private void checkBoxInvertColors_CheckedChanged(object sender, EventArgs e)
        {
            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;
            themeColorEvent.ChangeTheme(themeColorEvent.ForeColor, themeColorEvent.BackColor);
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            timerDropDown.Start();
        }

        private void timerDropDown_Tick(object sender, EventArgs e)
        {
            int interval = 10;

            if (btnDropDown.Text == "▲")
            {
                interval *= -1;
            }

            groupBox1.Height += interval;

            if (interval < 0 && btnDropDown.Bottom >= groupBox1.Bottom)
            {
                timerDropDown.Stop();
                btnDropDown.Text = "▼";
            }
            else
            {
                if (groupBox1.Bottom >= btnFeature2.Bottom)
                {
                    timerDropDown.Stop();
                    btnDropDown.Text = "▲";
                }
            }
        }
    }
}