using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLG.Objects
{
    public class FileCollection : Collection<File>
    {
        /// <summary>
        /// Create an empty FileCollection
        /// </summary>
        public FileCollection() : this(new List<File>()) {}

        /// <summary>
        /// Create an FileCollection using provided files
        /// </summary>
        /// <param name="list"></param>
        public FileCollection(List<File> list) : base(list) {}

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort() { ((List<File>)Items).Sort(); }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort(System.Comparison<File> comparer) { ((List<File>)Items).Sort(comparer); }
        
    }
}
