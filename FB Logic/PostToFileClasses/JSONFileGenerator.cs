using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FacebookWrapper.ObjectModel;

namespace FB_Logic.PostToFileClasses
{
    public class JSONFileGenerator : FileGenerator
    {

        public JSONFileGenerator(List<Post> i_PostsList, string i_FileName, string i_FilePath) : base(i_PostsList,
            i_FileName, i_FilePath)
        {

        }

        public override void CreateFileContents()
        {
           StringBuilder sb = new StringBuilder();
            sb.Append("{\"");
            sb.Append(FileName);
            sb.AppendLine("\":{");
            foreach (Post item in PostsList)
            {
                sb.Append("       \"Post\":\"");
                sb.Append(item.Message);
                sb.AppendLine("\",");
            }
            sb.AppendLine("     }\"");
            sb.AppendLine("}");
            FileContects = sb.ToString();
        }
    }

}
