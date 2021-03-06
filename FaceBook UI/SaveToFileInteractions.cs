﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FB_Logic;

namespace WinFormUI
{
    public partial class SaveToFileInteractions : Form
    {
        private UserAnalysis m_UserAnalysisLoaded;

        public UserAnalysis UserAnalysisLoaded
        {
            get
            {
                return m_UserAnalysisLoaded;
            }

            set
            {
                m_UserAnalysisLoaded = value;
                labelName.Text = m_UserAnalysisLoaded.UserIn.Name;
            }
        }

        public SaveToFileInteractions()
        {
            InitializeComponent();

            ThemeColor themeColorEvent = GenericSingletons.Singleton<ThemeColor>.Instance;
            themeColorEvent.ThemeChanged += themeColor_ChangedTheme;
            themeColor_ChangedTheme(themeColorEvent.BackColor, themeColorEvent.ForeColor);
        }

        private void themeColor_ChangedTheme(Color i_BackColor, Color i_ForeColor)
        {
            labelName.BackColor = i_BackColor;
            labelName.ForeColor = i_ForeColor;
            groupBoxExtra.BackColor = i_BackColor;
            groupBoxExtra.ForeColor = i_ForeColor;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            folderBrowserDialogPath.ShowDialog();
            string pathToSaveIn = folderBrowserDialogPath.SelectedPath;

            if (pathToSaveIn != string.Empty)
            {
                const string fileEnding = "txt";
                string finalPath = string.Format(
                    @"{0}\{1}.{2}", pathToSaveIn, labelName.Text, fileEnding);

                if (File.Exists(finalPath))
                {
                    File.Delete(finalPath);
                }

                File.AppendAllText(finalPath, allDataToSave());
                MessageBox.Show("Saved!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Choose a Valid Path.");
            }
        }

        private string allDataToSave()
        {
            StringBuilder stringBuilder = new StringBuilder(100);
            stringBuilder.AppendFormat(
        @"Name: {0}
Gold Stars: {1}
Normal Stars: {2}
", UserAnalysisLoaded.UserIn.Name
, UserAnalysisLoaded.MyStars.GoldenStars
, UserAnalysisLoaded.MyStars.NormalStars);

            if (checkBoxPosts.Checked)
            {
                stringBuilder.AppendFormat("Posts: {0}", UserAnalysisLoaded.PostInteraction).AppendLine();
            }

            if (checkBoxEvents.Checked)
            {
                stringBuilder.AppendFormat("Events: {0}", UserAnalysisLoaded.EventInteraction).AppendLine();
            }

            if (checkBoxCheckins.Checked)
            {
                stringBuilder.AppendFormat("Checkins: {0}", UserAnalysisLoaded.CheckinInteraction).AppendLine();
            }

            if (checkBoxTagged.Checked)
            {
                stringBuilder.AppendFormat("Tagged: {0}", UserAnalysisLoaded.TaggedInteraction).AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
