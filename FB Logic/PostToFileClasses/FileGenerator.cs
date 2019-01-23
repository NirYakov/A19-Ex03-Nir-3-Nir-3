using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FB_Logic
{
    public abstract class FileGenerator
    {
        public List<Post> PostsList { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FullPath { get; set; }
        public string FileContects { get; set; }

        public FileGenerator(List<Post> i_PostsList, String i_FileName, String i_FilePath)
        {
            PostsList = i_PostsList;
            FileName = i_FileName;
            FilePath = i_FilePath;
            SetFullPath();
            CreateFileContents();
            populateContectToFile();
        }

        private void SetFullPath()
        {
            FullPath = Path.Combine(FilePath, FileName);
        }

        private void populateContectToFile()
        {
            File.WriteAllText(FullPath, FileContects);
        }

        public abstract void CreateFileContents();
    }
}
