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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLG.SharedInterface
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
