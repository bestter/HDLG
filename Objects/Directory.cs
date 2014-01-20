using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HDLG.Objects
{
    /// <summary>
    /// Directory
    /// </summary>
    public class Directory
    {
        /// <summary>
        /// DirectoryInfo object about this directory
        /// </summary>
        public DirectoryInfo DirectoryInformation { get; private set; }

        /// <summary>
        /// Files
        /// </summary>
        public FileCollection Files { get; private set; }

        /// <summary>
        /// Create a new Directory
        /// </summary>
        /// <param name="directoryInfo"></param>
        public Directory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException("directoryInfo");
            }

            DirectoryInformation = directoryInfo;

            //Get files
            System.IO.FileInfo[] filesInfos = DirectoryInformation.GetFiles();
            Files = new FileCollection();
            //Get properties
            foreach (FileInfo fileInfo in filesInfos)
            {
                Files.Add(new File(fileInfo));
            }
            
            //Sort
            Files.Sort();

        }
    }
}
