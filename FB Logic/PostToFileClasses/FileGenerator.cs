using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public string FolderPath { get; set; }
        public string FullPath { get; set; }
        public string FileContects { get; set; }

        public FileGenerator(List<Post> i_PostsList, String i_FileName, String iFolderPath)
        {
            PostsList = i_PostsList;
            FileName = i_FileName;
            FolderPath = iFolderPath;
            setFullPath();
        }

        private void setFullPath()
        {
            FullPath = Path.Combine(FolderPath, FileName);
        }

        private void populateContentToFile()
        {
            File.WriteAllText(FullPath, FileContects);
        }

        public void CreateFile()
        {
            SetFileContents();
            populateContentToFile();
        }

        protected abstract void SetFileContents();
    }
}
