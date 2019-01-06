using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FB_Logic
{
    public class ProxyPostAnalisys : PostAnalysis
    {
        private List<Post> m_OfflinePostsList;

        public ProxyPostAnalisys(List<Post> i_OfflinePostsList) 
        {
            m_OfflinePostsList = i_OfflinePostsList;
            initPostList();
        }

        public void initPostList()
        {
            PostsList = m_OfflinePostsList;
        }
    }
}