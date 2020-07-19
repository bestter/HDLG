using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

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
