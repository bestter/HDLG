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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HDLG.ObjectsCore
{
    public class DirectoryCollection : ICollection<Directory>
    {
        private List<Directory> items;

        /// <summary>
        /// Create an empty DirectoryCollection
        /// </summary>
        public DirectoryCollection() : this(new List<Directory>()) { }

        /// <summary>
        /// Create an DirectoryCollection using provided directories
        /// </summary>
        /// <param name="list"></param>
        public DirectoryCollection(List<Directory> list) 
        { items = new List<Directory>(list); }

        /// <summary>
        /// Create an DirectoryCollection using provided directories
        /// </summary>
        /// <param name="list"></param>
        public DirectoryCollection(IEnumerable<Directory> list) : this(list.ToList()) { }

        public int Count => items.Count();

        public bool IsReadOnly => false;

        public void Add(Directory item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Directory item)
        {
            return items.Contains(item);
        }

        public void CopyTo(Directory[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Directory> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(Directory item)
        {
            return items.Remove(item);
        }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort() { items.Sort(); }

        /// <summary>
        /// Sort
        /// </summary>
        public void Sort(System.Comparison<Directory> comparer) { items.Sort(comparer); }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
