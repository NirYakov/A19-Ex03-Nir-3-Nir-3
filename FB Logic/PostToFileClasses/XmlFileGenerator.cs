using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using FacebookWrapper.ObjectModel;

namespace FB_Logic 
{
    public class XmlFileGenerator : FileGenerator
    {
        public XmlFileGenerator(List<Post> i_PostsList, string i_FileName, string iFolderPath) : base(i_PostsList, String.Format("{0}.xml", i_FileName), iFolderPath)
        {
        }

        public override void SetFileContents()
        {
            XElement rootElement = new XElement("Posts-List", FileName);

            foreach (Post item in PostsList)
            {
                XElement childElement = new XElement("Post", item.Message);
                rootElement.Add(childElement);
            }

            FileContects = rootElement.ToString();
        }
    }
}
