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
        /// <param name="directory">Directory to </param>
        public static HDLG.Objects.Directory GetDirectoryInformation(DirectoryInfo directory)
        {
            if (directory == null)
            {
                throw new ArgumentNullException("directory");
            }
            DirectoryInfo directoryInfo = directory;

            return LoadDirectory(directoryInfo);
        }

        /// <summary>
        /// Init directory
        /// </summary>
        private static Objects.Directory LoadDirectory(DirectoryInfo directory)
        {
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, "Directory {0} do not exist", directory.FullName));
            }

            return new Objects.Directory(directory);
        }
    }
}
