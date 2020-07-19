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

using System.IO;

namespace HDLG.SharedInterface
{
    public interface IPlugin
    {
        /// <summary>
        /// Get list of supported extensions
        /// </summary>
        /// <returns></returns>
        string[] GetSupportedExtensions();

        /// <summary>
        /// Get list of properties returned by this plugin
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>List of properties</returns>
        PropertyCollection GetProperties(FileInfo file);
    }
}
