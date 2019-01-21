using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Logic
{
    public abstract class FileGenerator
    {
        public String m_FileName { get; set; }
        public String m_FilePath { get; set; }

        public FileGenerator(String i_FileName, String i_FilePath)
        {
            m_FileName = i_FileName;
            m_FilePath = i_FilePath;
        }

        public abstract void writeToFile();
    }
}
