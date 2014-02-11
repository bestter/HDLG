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
    public class Directory : IComparable, IEquatable<Directory>
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

        public override string ToString()
        {
            return DirectoryInformation.FullName;            
        }

        public override int GetHashCode()
        {
            return DirectoryInformation.GetHashCode();
        }

        /// <summary>
        /// Is obj is equal to current Directory?
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>Is equal?</returns>
        public override bool Equals(object obj)
        {
            bool isEqual = false;

            if (obj != null && obj is Directory)
            {
                Directory other = (Directory)obj;

            }            

            return isEqual;
        }

        /// <summary>
        /// Is other is equal to current Directory?
        /// </summary>
        /// <param name="other">Directory to compare</param>
        /// <returns>Is equal?</returns>
        public bool Equals(Directory other)
        {
            bool isEqual = false;

            if (other != null)
            {
                isEqual = this.DirectoryInformation.Equals(other.DirectoryInformation);
            }

            return isEqual;
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
