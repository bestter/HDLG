/*
    This file is part of HTML Directory List Generator (HDLG).

    HDLG is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    HDLG is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with HDLG.  If not, see <http://www.gnu.org/licenses/>.
*/

using HDLG.SharedInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLG.ObjectsCore
{
    /// <summary>
    /// File
    /// </summary>
    public class File : IComparable
    {
        /// <summary>
        /// FileInfo object about this File
        /// </summary>
        public FileInfo FileInformation { get; private set; }

        public PropertyCollection PropertyCollection { get; private set; }

        /// <summary>
        /// Create a new File object
        /// </summary>
        /// <param name="fileInformation">fileInformation</param>
        public File(FileInfo fileInformation, IEnumerable<Property> properties)
        {
            FileInformation = fileInformation ?? throw new ArgumentNullException(nameof(fileInformation));
            PropertyCollection = new PropertyCollection(properties);
            Init();
        }

        /// <summary>
        /// Create a new File object
        /// </summary>
        /// <param name="filePath">File</param>
        public File(string filePath, IEnumerable<Property> properties)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            FileInformation = new FileInfo(filePath);
            PropertyCollection = new PropertyCollection(properties);
            Init();
        }

        /// <summary>
        /// Init
        /// </summary>
        private void Init()
        {
            if (!FileInformation.Exists)
            {
                throw new FileNotFoundException(string.Format("File {0} not found", FileInformation.FullName), FileInformation.FullName);
            }

        }

        public override string ToString()
        {
            return FileInformation.FullName;
        }

        public override int GetHashCode()
        {
            return FileInformation.GetHashCode();
        }

        /// <summary>
        /// Is obj is equal to current file
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Is equal?</returns>
        public override bool Equals(object obj)
        {
            bool isEqual = false;

            if (obj != null && obj is File)
            {

            }

            return isEqual;
        }

        /// <summary>
        /// Is file is equal to current file
        /// </summary>
        /// <param name="file">File to compare</param>
        /// <returns>Is equal?</returns>
        public bool Equals(File file)
        {
            bool isEqual = false;

            if (file != null)
            {
                isEqual = file.FileInformation.Equals(this.FileInformation);
            }

            return isEqual;
        }

        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object other)
        {
            if (other == null)
            {
                return -1;
            }
            if (!(other is File))
            {
                return -1;
            }
            else
            {
                File f2 = (File)other;
                return this.CompareTo(f2);
            }
        }

        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(File other)
        {
            int compareValue = 0;
            if (other == null)
            {
                compareValue = -1;
            }
            else
            {
                if (this.FileInformation != null)
                {
                    if (other.FileInformation != null)
                    {
                        compareValue = this.FileInformation.FullName.CompareTo(other.FileInformation.FullName);
                    }
                    else
                    {
                        compareValue = -1;
                    }
                }
                else
                {
                    if (other.FileInformation != null)
                    {
                        compareValue = 1;
                    }
                    else
                    {
                        compareValue = 0;
                    }
                }
            }

            return compareValue;
        }
    }
}
