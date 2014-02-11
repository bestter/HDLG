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
    public class Directory : IComparable
    {
        /// <summary>
        /// DirectoryInfo object about this directory
        /// </summary>
        public DirectoryInfo DirectoryInformation { get; private set; }

        /// <summary>
        /// Files
        /// </summary>
        public FileCollection Files { get; set; }

        /// <summary>
        /// SubDirectories
        /// </summary>
        public DirectoryCollection SubDirectories { get; set; }

        /// <summary>
        /// Create a new Directory
        /// </summary>
        /// <param name="directoryInfo">Directory</param>
        public Directory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException("directoryInfo");
            }

            DirectoryInformation = directoryInfo;
        }

        /// <summary>
        /// Create a new Directory
        /// </summary>
        /// <param name="directoryInfo">Directory</param>
        /// <param name="fileCollection">FileCollection</param>
        /// <param name="subDirectoryCollection">SubDirectoryCollection</param>
        public Directory(DirectoryInfo directoryInfo, FileCollection fileCollection, DirectoryCollection subDirectoryCollection)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException("directoryInfo");
            }

            DirectoryInformation = directoryInfo;
            Files = fileCollection;
            SubDirectories = subDirectoryCollection;
        }

        /// <summary>
        /// CompareTo
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>CompareValue</returns>
        public int CompareTo(object obj)
        {
            int compareValue = 0;

            if (obj == null)
            {
                compareValue = -1;
            }
            else
            {
                if (obj is Directory)
                {
                    Directory directory = (Directory)obj;
                    return this.CompareTo(directory);
                }
                else
                {
                    compareValue = -1;
                }
            }


            return compareValue;
        }

        /// <summary>
        /// CompareTo
        /// </summary>
        /// <param name="other">Other directory</param>
        /// <returns>CompareValue</returns>
        public int CompareTo(Directory other)
        {
            int compareValue = 0;


            if (other == null)
            {
                compareValue = -1;
            }
            else
            {
                this.DirectoryInformation.FullName.CompareTo(other.DirectoryInformation.FullName);
            }

            return compareValue;
        }
    }
}
