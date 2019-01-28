using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FB_Logic
{
    public class SimpleTextFileGenertor : FileGenerator
    {
        public SimpleTextFileGenertor(List<Post> i_PostsList, string i_FileName, string iFolderPath) : base(i_PostsList, String.Format("{0}.txt", i_FileName), iFolderPath)
        {
        }

        protected override void SetFileContents()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(FileName);
            int counter = 1;
            foreach (Post post in PostsList)
            {
                sb.Append(counter++);
                sb.Append(") ");
                sb.AppendLine(post.Message);
            }

            FileContects = sb.ToString();
        }
    }
}
