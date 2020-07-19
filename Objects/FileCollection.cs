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

namespace HDLG.Objects
{
    public class FileCollection : ICollection<File>
    {
        private List<File> items;

        /// <summary>
        /// Create an empty FileCollection
        /// </summary>
        public FileCollection() : this(new List<File>()) { }

        /// <summary>
        /// Create an FileCollection using provided files
        /// </summary>
        /// <param name="list"></param>
        public FileCollection(List<File> list)
        {
            items = list;
        }

        /// <summary>
        /// Create an FileCollection using provided files
        /// </summary>
        /// <param name="list"></param>
        public FileCollection(IEnumerable<File> list) : this(list.ToList()) { }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public void Add(File item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(File item)
        {
            return items.Contains(item);
        }

        public void CopyTo(File[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<File> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(File item)
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
        public void Sort(System.Comparison<File> comparer) { items.Sort(comparer); }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
