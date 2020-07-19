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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace HDLG.SharedInterface
{
    /// <summary>
    /// Wrong file extension
    /// </summary>
    public class WrongFileFormatException : Exception, ISerializable
    {
        /// <summary>
        /// Wrong file extension
        /// </summary>
        /// <param name="message"></param>
        public WrongFileFormatException(string message) : base(message) { }

        /// <summary>
        /// Wrong file extension
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public WrongFileFormatException(string message, Exception inner) : base(message, inner) { }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
