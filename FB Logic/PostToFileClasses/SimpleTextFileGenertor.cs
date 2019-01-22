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
        public SimpleTextFileGenertor(List<Post> i_PostsList, string i_FileName, string i_FilePath) : base(i_PostsList,i_FileName, i_FilePath)
        {
        }

        public override void CreateFileContents()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(FileName);
            int counter = 1;
            foreach (var post in PostsList)
            {
                sb.Append(counter++);
                sb.Append(") ");
                sb.AppendLine(post.Message);
            }

            FileContects = sb.ToString();
        }
    }
}
