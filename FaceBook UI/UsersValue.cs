using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FB_Logic;

namespace WinFormUI
{
    public partial class UsersValue : Form
    {
        private readonly List<PictureTopBar> r_PictureTopBars;
        private Color m_BackColor;
        private Color m_ForeColor;
        private UserAnalysis m_LoadedUserAnalysis;
        private PicturesManager m_PicutresManager;
        private int m_InitSortGroupBoxHeight = 0;
        private const float k_SizeIntervalOfPtb = 0.85f;
        private string k_BringAlbumsString =
@"Bring
{0}
&Albums";

        private const string k_HelpMessage =
@"Hello,
Here in UserValue you can know if some one
of your friends or even you worth to invest
moeny in advertisement (like watch ad in 
status or swimsuits in picture upload).
our system is give stars for every one by demand.
with the stars you can know
who have more interaction in there account and by
this stars you can decided if you want to invest in
the use or skip to next one . you can to know your
value as well.
Gold star is equal to {0} normal stars
and how the likes and comments became the stars it
our secret. Thank and have fun.

p.s
Interction button calculate user loaded stars.
Refresh button bring back the names to friends.
Sort By -> it's analysis all your friends
by given fields , and sort the best to top.";

        public UsersValue()
        {
            InitializeComponent();
            r_PictureTopBars = new List<PictureTopBar>();
            initializeAll();
        }

        private void initializeAll()
        {
            m_PicutresManager = new PicturesManager() { MyAlbums = UserManager.User.Albums };
            m_InitSortGroupBoxHeight = groupBoxSortOpt.Height;
            m_LoadedUserAnalysis = new UserAnalysis() { UserIn = UserManager.User };
            pictureBoxLaodedUser.LoadAsync(m_LoadedUserAnalysis.UserIn.PictureSqaureURL);
            initSettings();
            initListView();
        }

        private void initSettings()
        {
            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;
            themeColorEvent.ThemeChanged += themeColor_ChangedTheme;
            themeColor_ChangedTheme(themeColorEvent.BackColor, themeColorEvent.ForeColor);

            PictureTopBar ptb = newPictureTopBar(UserManager.UserName, UserManager.UserPictureUrl);
            ptb.AddToClickEvent(pictureTopBar_Click);
            ptb.MyUserAnalysis.UserIn = UserManager.User;
            r_PictureTopBars.Add(ptb);
            flowLayoutPanelFriends.Controls.Add(ptb);
        }

        private void themeColor_ChangedTheme(Color i_BackColor, Color i_ForeColor)
        {
            m_BackColor = i_BackColor;
            m_ForeColor = i_ForeColor;

            groupBoxSortOpt.BackColor = m_BackColor;
            groupBoxSortOpt.ForeColor = m_ForeColor;
            checkBoxCheckin.ForeColor = m_ForeColor;
            checkBoxEvents.ForeColor = m_ForeColor;
            checkBoxPosts.ForeColor = m_ForeColor;
            checkBoxTagged.ForeColor = m_ForeColor;

            buttonHelp.BackColor = m_BackColor;
            buttonHelp.ForeColor = m_ForeColor;

            groupBox2.BackColor = m_BackColor;
            groupBox2.ForeColor = m_ForeColor;
            labelTheName.ForeColor = m_ForeColor;
            labelName.ForeColor = m_ForeColor;
            label3.ForeColor = m_ForeColor;
            label5.ForeColor = m_ForeColor;
            label7.ForeColor = m_ForeColor;
            label2.ForeColor = m_ForeColor;
            labelTheTown.ForeColor = m_ForeColor;
            labelTheFirendsCount.ForeColor = m_ForeColor;
            labelTheTagged.ForeColor = m_ForeColor;
            labelBDay.ForeColor = m_ForeColor;

            foreach (PictureTopBar item in flowLayoutPanelFriends.Controls)
            {
                item.TopPanel.BackColor = i_BackColor;
                item.LabelText.ForeColor = i_ForeColor;
            }

            foreach (PictureTopBar item in flowLayoutPanelPickedUserPictures.Controls)
            {
                item.TopPanel.BackColor = i_BackColor;
                item.LabelText.ForeColor = i_ForeColor;
            }
        }

        private void initListView()
        {
            imageListPickedUserAlbumsPictures.ColorDepth = ColorDepth.Depth32Bit;
            imageListPickedUserAlbumsPictures.ImageSize = new Size(80, 80);
            listViewPickedUserAlbums.View = View.LargeIcon;
            listViewPickedUserAlbums.LargeImageList = imageListPickedUserAlbumsPictures;
        }

        private void bringFriendsAndLoadTheFriendsList()
        {
            try
            {
                PictureTopBar ptb;

                foreach (User friend in UserManager.User.Friends)
                {
                    ptb = newPictureTopBar(string.Format("{0}", friend.Name), friend.PictureLargeURL);
                    ptb.MyUserAnalysis.UserIn = friend;
                    ptb.AddToClickEvent(pictureTopBar_Click);
                    r_PictureTopBars.Add(ptb);
                    flowLayoutPanelFriends.Invoke(new Action(() => flowLayoutPanelFriends.Controls.Add(ptb)));
                    friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                }

                int friendsNumber = UserManager.User.Friends.Count;
                if (friendsNumber == 0)
                {
                    MessageBox.Show("No Friends to retrieve :(");
                }
            }
            catch (Exception)
            {
                serviceNotAvailableMessage();
            }
        }

        private PictureTopBar newPictureTopBar(string i_LabelTitle, string i_PictureUrl)
        {
            PictureTopBar ptb = new PictureTopBar() { Size = new Size((int)(200 * k_SizeIntervalOfPtb), (int)(250 * k_SizeIntervalOfPtb)) };
            ptb.TopPanel.BackColor = m_BackColor;
            ptb.LabelText.ForeColor = m_ForeColor;
            ptb.Picture.LoadAsync(i_PictureUrl);
            ptb.LabelText.Text = i_LabelTitle;
            return ptb;
        }

        private void pictureTopBar_Click(object sender, EventArgs e)
        {
            PictureTopBar ptb = sender as PictureTopBar;
            if (ptb != null)
            {
                try
                {
                    updateUserLoadedInfo(ptb.MyUserAnalysis);
                }
                catch (Exception)
                {
                    serviceNotAvailableMessage();
                }
            }
        }

        private void updateUserLoadedInfo(UserAnalysis i_UserAnalysis)
        {
            labelTheName.Text = i_UserAnalysis.UserIn.Name;
            buttonFetchAlbums.Text = string.Format(k_BringAlbumsString, labelTheName.Text);
            buttonSaveToFile.Enabled = false;
            labelTheFirendsCount.Text = i_UserAnalysis.UserIn.Friends.Count.ToString();
            m_LoadedUserAnalysis = i_UserAnalysis;
            m_PicutresManager.MyAlbums = i_UserAnalysis.UserIn.Albums;
            const bool showAlbumList = true, showPictureList = true;
            clearImagesAlbumAndPicturesContainers(showAlbumList, !showPictureList);
            pictureBoxLaodedUser.LoadAsync(i_UserAnalysis.UserIn.PictureSqaureURL);
            labelBDay.Text = i_UserAnalysis.UserIn.Birthday;
            labelTheTagged.Text = i_UserAnalysis.UserIn.PhotosTaggedIn.Count.ToString();
        }

        private void buttonInteraction_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(interactionCalc)).Start();
        }

        private void interactionCalc()
        {
            try
            {
                if (m_LoadedUserAnalysis.UserIn != null)
                {
                    labelNameInteraction.Invoke(new Action(() =>
                    labelNameInteraction.Text = m_LoadedUserAnalysis.UserIn.Name));

                    this.Invoke(new Action(() => calculateAndFillDataUser()));

                    m_LoadedUserAnalysis.MyStars.CalulateStars(
                        m_LoadedUserAnalysis.PostInteraction,
                        m_LoadedUserAnalysis.EventInteraction,
                        m_LoadedUserAnalysis.CheckinInteraction,
                        m_LoadedUserAnalysis.TaggedInteraction
                        );

                    labelGoldStarsInteraction.Invoke(new Action(() =>
                    labelGoldStarsInteraction.Text = m_LoadedUserAnalysis.MyStars.GoldenStars.ToString()));

                    labelNormalStarsInteraction.Invoke(new Action(() =>
                    labelNormalStarsInteraction.Text = m_LoadedUserAnalysis.MyStars.NormalStars.ToString()));

                    buttonSaveToFile.Invoke(new Action(() => buttonSaveToFile.Enabled = true));
                }
            }
            catch (Exception)
            {
                serviceNotAvailableMessage();
            }
        }

        private void calculateAndFillDataUser()
        {
            labelEventInteraction.Text = m_LoadedUserAnalysis.PostInteraction.ToString();
            labelPostInteraction.Text = m_LoadedUserAnalysis.ToString();
            labelCheckinInterctions.Text = m_LoadedUserAnalysis.ToString();
            labelTaggedInterctions.Text = m_LoadedUserAnalysis.ToString();
        }

        private void serviceNotAvailableMessage()
        {
            MessageBox.Show(
 @"The Service not available now
Try Later");
        }

        private void radioButtonHideSort_CheckedChanged(object sender, EventArgs e)
        {
            timerSort.Start();
        }

        private void timerSort_Tick(object sender, EventArgs e)
        {
            const int intervalMoving = 10;
            if (radioButtonHideSort.Checked == true)
            {
                movingMiddle(-intervalMoving);
                if (groupBoxSortOpt.Height <= 0)
                {
                    timerSort.Stop();
                    this.Refresh();
                }
            }
            else
            {
                movingMiddle(intervalMoving);
                if (groupBoxSortOpt.Height >= m_InitSortGroupBoxHeight)
                {
                    timerSort.Stop();
                    this.Refresh();
                }
            }
        }

        private void movingMiddle(int i_IntervalMoving)
        {
            groupBoxSortOpt.Height += i_IntervalMoving;
            groupBoxAdvenceOpt.Top += i_IntervalMoving;
            panelMainData.Top += i_IntervalMoving;
            buttonHelp.Top += i_IntervalMoving;
        }

        private UserAnalysis.eStarsParameters sortParametersPicked()
        {
            UserAnalysis.eStarsParameters chosenParams = UserAnalysis.eStarsParameters.None;
            if (checkBoxCheckin.Checked == true)
            {
                chosenParams |= UserAnalysis.eStarsParameters.Checkin;
            }

            if (checkBoxCheckin.Checked == true)
            {
                chosenParams |= UserAnalysis.eStarsParameters.Posts;
            }

            if (checkBoxCheckin.Checked == true)
            {
                chosenParams |= UserAnalysis.eStarsParameters.Events;
            }

            if (checkBoxCheckin.Checked == true)
            {
                chosenParams |= UserAnalysis.eStarsParameters.Tagged;
            }

            return chosenParams;
        }

        private void buttonActiveSort_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(activeSortWithParameters)).Start();
        }

        private void activeSortWithParameters()
        {
            UserAnalysis.eStarsParameters chosenParams = sortParametersPicked();
            if (chosenParams != UserAnalysis.eStarsParameters.None)
            {
                try
                {
                    foreach (PictureTopBar item in r_PictureTopBars)
                    {
                        item.MyUserAnalysis.ClacStarsFromAnalisis(chosenParams);
                    }

                    r_PictureTopBars.Sort(new PictureTopBarStarSort());
                    flowLayoutPanelFriends.Invoke(new Action(() => flowLayoutPanelFriends.Controls.Clear()));
                    foreach (PictureTopBar item in r_PictureTopBars)
                    {
                        item.Invoke(new Action(() =>
                        item.LabelText.Text = string.Format("{0} Gold ,{1} normal stars"
                            , item.MyUserAnalysis.MyStars.GoldenStars, item.MyUserAnalysis.MyStars.NormalStars)));
                        flowLayoutPanelFriends.Invoke(new Action(() => flowLayoutPanelFriends.Controls.Add(item)));
                    }
                }
                catch (Exception)
                {
                    serviceNotAvailableMessage();
                }
            }
        }

        private void buttonFetchAlbums_Click(object sender, EventArgs e)
        {
            const bool showAlbumList = true, showPictureList = true;
            clearImagesAlbumAndPicturesContainers(showAlbumList, !showPictureList);

            try
            {
                bringAndLoadAlbums();
                buttonGetPhotos.Enabled = true;
            }
            catch (Exception)
            {
                serviceNotAvailableMessage();
            }
        }

        private void bringAndLoadAlbums()
        {
            bringPickedUserAlbums();
        }

        private void bringPickedUserAlbums()
        {
            List<ItemInfo> allAlbums = (List<ItemInfo>)m_PicutresManager.BringAllAlbums();
            int index = 0;
            foreach (ItemInfo itemInfo in allAlbums)
            {
                var request = WebRequest.Create(itemInfo.ItemUrl);
                using (WebResponse response = request.GetResponse())
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    imageListPickedUserAlbumsPictures.Images.Add(Bitmap.FromStream(stream));
                }

                listViewPickedUserAlbums.Items.Add(new ListViewItem()
                {
                    ImageIndex = index++,
                    Text = itemInfo.ItemName
                });
            }

            if (index == 0)
            {
                MessageBox.Show("Nothing!");
            }
        }

        private void clearImagesAlbumAndPicturesContainers(bool i_ShowAlbumList, bool i_ShowPictureList)
        {
            listViewPickedUserAlbums.Clear();
            imageListPickedUserAlbumsPictures.Images.Clear();
            listViewPickedUserAlbums.Visible = i_ShowAlbumList;
            flowLayoutPanelPickedUserPictures.Visible = i_ShowPictureList;
            flowLayoutPanelPickedUserPictures.Controls.Clear();
        }

        private void buttonGetPhotos_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listViewPickedUserAlbums.SelectedItems[0].Index;
                if (index >= 0 && index < listViewPickedUserAlbums.Items.Count)
                {
                    const bool showAlbumList = true, showPictureList = true;
                    clearImagesAlbumAndPicturesContainers(!showAlbumList, showPictureList);
                    ICollection<PictureAnalysis> pictureAnalyses =
                        fillPictureAnalysisListAndSortByStars(index);

                    foreach (PictureAnalysis item in pictureAnalyses)
                    {
                        flowLayoutPanelPickedUserPictures.Controls.Add(
                            newPictureTopBar(item.ToString(), item.PictureUrl));
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Plase pick anther item. you picked wrong index.");
            }
            catch (FieldAccessException)
            {
                MessageBox.Show("Plase pick anther item. you picked wrong index. HERERE?");
            }
            catch (Exception)
            {
                serviceNotAvailableMessage();
            }
        }

        private ICollection<PictureAnalysis> fillPictureAnalysisListAndSortByStars(int i_Index)
        {
            List<PictureAnalysis> pictureAnalyses = new List<PictureAnalysis>();
            PictureAnalysis pictureAnalysis;
            foreach (Photo item in m_PicutresManager.AlbumAt(i_Index).Photos)
            {
                pictureAnalysis = new PictureAnalysis
                {
                    PictureUrl = item.PictureNormalURL,
                    PictureID = item.Id
                };

                pictureAnalysis.CalcStars(item.LikedBy.Count, item.Comments.Count);
                pictureAnalyses.Add(pictureAnalysis);
            }

            pictureAnalyses.Sort();
            return pictureAnalyses;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFriends.Controls.Clear();
            foreach (PictureTopBar item in r_PictureTopBars)
            {
                item.LabelText.Text = item.MyUserAnalysis.UserIn.Name;
                flowLayoutPanelFriends.Controls.Add(item);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(k_HelpMessage, Stars.GoldStarBar), "Helper for help");
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new SaveToFileInteractions()
            {
                UserAnalysisLoaded = m_LoadedUserAnalysis
            }).ShowDialog();
            this.Show();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            new Thread(new ThreadStart(() => bringFriendsAndLoadTheFriendsList())).Start();
        }

        private class PictureTopBarStarSort : IComparer<PictureTopBar>
        {
            public int Compare(PictureTopBar i_X, PictureTopBar i_Y)
            {
                return i_X.MyUserAnalysis.CompareTo(i_Y.MyUserAnalysis);
            }
        }
    }
}