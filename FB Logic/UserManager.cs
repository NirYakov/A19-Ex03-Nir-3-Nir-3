using System;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FB_Logic
{
    public static class UserManager
    {
        private const string k_AppID = "510658539406597"; // "510658539406597"; // "317399492389792"; 
        private const string k_GuyAppID = "1450160541956417";
        private static User s_LoggedInUser;

        public static void Login()
        {
            LoginResult m_LoginResult = FacebookService.Login(
               //   k_AppID,
              k_GuyAppID ,
            "public_profile",
            "user_birthday",
            "user_friends",
            "user_events",
            "user_hometown",
            "user_likes",
            "user_location",
            "user_photos",
            "user_posts",
            "user_tagged_places",
            "user_videos",
            "manage_pages",
            "publish_pages"
           );

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                s_LoggedInUser = m_LoginResult.LoggedInUser;
            }
            else
            {
                throw new Exception(m_LoginResult.ErrorMessage);
            }
        }

        public static User User
        {
            get { return s_LoggedInUser; }
        }

        public static string UserName
        {
            get { return s_LoggedInUser.Name; }
        }

        public static string UserPictureUrl
        {
            get { return s_LoggedInUser.PictureNormalURL; }
        }

        public static void UserLogOut()
        {
            FacebookService.Logout(new Action(() => { }));
        }

        public static string UserPictureUrlCover
        {
            get { return s_LoggedInUser.Cover.SourceURL; }
        }      
    }
}