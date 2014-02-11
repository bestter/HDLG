using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLG.Objects
{
    public class DirectoryCollection : Collection<Directory>
    {
        /// <summary>
        /// Create an empty DirectoryCollection
        /// </summary>
        public DirectoryCollection() : this(new List<Directory>()) { }

        /// <summary>
        /// Create an DirectoryCollection using provided directories
        /// </summary>
        /// <param name="list"></param>
        public DirectoryCollection(List<Directory> list) : base(list) { }

        /// <summary>
        /// Create an DirectoryCollection using provided directories
        /// </summary>
        /// <param name="list"></param>
        public DirectoryCollection(IEnumerable<Directory> list) : base(list.ToList()) { }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort() { ((List<Directory>)Items).Sort(); }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort(System.Comparison<Directory> comparer) { ((List<Directory>)Items).Sort(comparer); }
        
    }
}
