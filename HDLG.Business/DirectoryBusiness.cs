using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HDLG.Objects;
using System.Globalization;

namespace HDLG.Business
{
    public static class DirectoryBusiness
    {
        
        public static HDLG.Objects.Directory GetDirectoryInformation(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentNullException("directoryPath");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            
            return LoadDirectory(directoryInfo);
        }

        /// <summary>
        /// Create a new DirectoryBusiness
        /// </summary>
        /// <param name="directoryInfo">Directory to </param>
        public static HDLG.Objects.Directory GetDirectoryInformation(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException("directory");
            }
            
            return LoadDirectory(directoryInfo);
        }

        /// <summary>
        /// Init directory
        /// </summary>
        private static Objects.Directory LoadDirectory(DirectoryInfo directoryInfo)
        {
            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, "Directory {0} do not exist", directoryInfo.FullName));
            }

            //Get files
            System.IO.FileInfo[] filesInfos = new FileInfo[1];
            try
            {
                filesInfos = directoryInfo.GetFiles();
            }
            catch
            {
            }
            
            FileCollection Files = new FileCollection();
            //Get properties
            foreach (FileInfo fileInfo in filesInfos)
            {
                Files.Add(new Objects.File(fileInfo));
            }
            //Sort
            Files.Sort();
            //Get files information...


            //Load directories
            DirectoryInfo[] directoryInfos = new DirectoryInfo[1];
            try
            {
                directoryInfos = directoryInfo.GetDirectories();
            }
            catch
            {
            }
            DirectoryCollection Directories = new DirectoryCollection();
            foreach (DirectoryInfo di in directoryInfos)
            {
                HDLG.Objects.Directory dir = DirectoryBusiness.GetDirectoryInformation(di);                
                Directories.Add(dir);
            }
            //Sort
            Directories.Sort();

            //Create directory
            Objects.Directory directory = new Objects.Directory(directoryInfo, Files, Directories);            

            return directory;
        }

        /// <summary>
        /// Save directory to HTML
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePath"></param>
        public static void SaveToHtml(HDLG.Objects.Directory directory, string filePath)
        {
        }

        /// <summary>
        /// Save directory to XML
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePath"></param>
        public static void SaveToXML(HDLG.Objects.Directory directory, string filePath)
        {
        }


    }
}
