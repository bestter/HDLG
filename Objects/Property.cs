﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLG.Objects
{
    public class Property: IComparable
    {
        #region Properties
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; set; }
        #endregion

        /// <summary>
        /// Create a new Property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Property(string name, object value)        
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name);
            }

            Name = name;
            Value = value;
        }

        /// <summary>
        /// Create a new Property
        /// </summary>
        /// <param name="nameValue"></param>
        public Property(KeyValuePair<string, object> nameValue)
        {
            if (string.IsNullOrEmpty(nameValue.Key))
            {
                throw new ArgumentNullException("key");
            }

            Name = nameValue.Key;
            Value = nameValue.Value;
        }


        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }
            if (other is Property)
            {
                Property p2 = (Property)other;
                return this.Name.Equals(p2.Name);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Compare this with another object
        /// </summary>
        /// <param name="other">Other object</param>
        /// <returns>CompareValue</returns>
        public int CompareTo(object other)
        {
            if (other == null)
            {
                return -1;
            }
            if (other is Property)
            {
                Property propertyB = (Property)other;
                return this.CompareTo(propertyB);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Property other)
        {
            int compareValue = 0;
            if (other == null)
            {
                compareValue = -1;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    if (!string.IsNullOrEmpty(other.Name))
                    {
                        compareValue = this.Name.CompareTo(other.Name);
                    }
                    else
                    {
                        compareValue = -1;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(other.Name))
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
