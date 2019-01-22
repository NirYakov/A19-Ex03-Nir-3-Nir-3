using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FB_Logic 
{
    public class XmlFileGenerator : FileGenerator
    {
        public XmlFileGenerator(List<Post> i_PostsList, string i_FileName, string i_FilePath) : base(i_PostsList, i_FileName, i_FilePath)
        {

        }

        public override void CreateFileContents()
        {
            throw new NotImplementedException();
        }
    }

}
