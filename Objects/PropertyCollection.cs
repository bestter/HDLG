using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLG.Objects
{
    public class PropertyCollection : Collection<Property>
    {
        /// <summary>
        /// Create an empty PropertyCollection
        /// </summary>
        public PropertyCollection() : this(new List<Property>()) { }

        /// <summary>
        /// Create an PropertyCollection using provided properties
        /// </summary>
        /// <param name="list"></param>
        public PropertyCollection(List<Property> list) : base(list) { }

        /// <summary>
        /// Create an PropertyCollection using provided properties
        /// </summary>
        /// <param name="list"></param>
        public PropertyCollection(IEnumerable<Property> list) : base(list.ToList()) { }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort() { ((List<Property>)Items).Sort(); }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort(System.Comparison<Property> comparer) { ((List<Property>)Items).Sort(comparer); }

    }
}
