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

using HDLG.ObjectsCore;
using HDLG.SharedInterface;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace HDLG.BusinessCore
{
    public static class DirectoryBusiness
    {

        public static ObjectsCore.Directory GetDirectoryInformation(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentNullException(nameof(directoryPath));
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            return LoadDirectory(directoryInfo);
        }

        /// <summary>
        /// Create a new DirectoryBusiness
        /// </summary>
        /// <param name="directoryInfo">Directory to </param>
        public static ObjectsCore.Directory GetDirectoryInformation(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            return LoadDirectory(directoryInfo);
        }

        /// <summary>
        /// Init directory
        /// </summary>
        private static ObjectsCore.Directory LoadDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo is null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, "Directory {0} do not exist", directoryInfo.FullName));
            }

            //Get files
            FileInfo[] filesInfos = new FileInfo[1];
               filesInfos = directoryInfo.GetFiles();


            FileCollection Files = new FileCollection();
            //Get properties
            foreach (FileInfo fileInfo in filesInfos)
            {
                if (fileInfo != null)
                {
                    //Get properties
                    PropertyCollection properties = new PropertyCollection();

                    //Get list of plugins

                    IPlugin jpegplugin = (IPlugin)Activator.CreateInstance(Type.GetType("HDLG.ImagesPlugin.JpegPlugin, HDLG.ImagesPlugin", true));

                    if (jpegplugin.GetSupportedExtensions().Contains(fileInfo.Extension))
                    {
                        properties = jpegplugin.GetProperties(fileInfo);
                    }

                    //Add file
                    Files.Add(new ObjectsCore.File(fileInfo, properties));
                }
            }
            //Sort
            Files.Sort();


            //Load directories
            DirectoryInfo[] directoryInfos = new DirectoryInfo[1];
            try
            {
                directoryInfos = directoryInfo.GetDirectories();
            }
            catch
            {
            }
            DirectoryCollection Directories = new DirectoryCollection();
            foreach (DirectoryInfo di in directoryInfos)
            {
                if (di != null)
                {
                    Directories.Add(GetDirectoryInformation(di));
                }
            }
            //Sort
            Directories.Sort();

            //Create directory
            ObjectsCore.Directory directory = new ObjectsCore.Directory(directoryInfo, Files, Directories);

            return directory;
        }

        #region HTML

        /// <summary>
        /// Save directory to HTML
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePath"></param>
        public static void SaveToHtml(ObjectsCore.Directory directory, string filePath)
        {
            string htmlSourceFile = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "hdlgDirectories.html"));


            string workFile = htmlSourceFile.Replace("<title></title>", string.Format(CultureInfo.CurrentCulture, "<title>Content of directory {0}</title>", directory.DirectoryInformation.FullName));

            StringBuilder strb = new StringBuilder();

            strb.AppendLine("\t<div>");
            strb.AppendLine("\t\t<ul>");

            strb.AppendLine(WriteDirectoryToHTML(directory, 0));

            strb.AppendLine("\t\t</ul>");
            strb.AppendLine("\t</div>");

            //Replace...
            workFile = workFile.Replace("</body>", string.Format(CultureInfo.CurrentCulture, "{0}{1}</body>", strb.ToString().Trim(), Environment.NewLine));


            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(workFile.Trim());
                    writer.Flush();
                }
            }
        }


        /// <summary>
        /// Write a directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="deepCounter"></param>
        /// <returns></returns>
        private static string WriteDirectoryToHTML(ObjectsCore.Directory directory, int deepCounter)
        {
            StringBuilder strb = new StringBuilder();


            int deepCounterToUse = deepCounter + 1;

            string tabs = new String('\t', deepCounterToUse);
            string internalTabs = new String('\t', deepCounterToUse + 1);

            strb.AppendLine(internalTabs + "<li>");
            strb.AppendLine(internalTabs + "<div class=\"directory\">");


            strb.AppendLine(internalTabs + "<h2>" + directory.DirectoryInformation.Name + "</h2>");

            strb.AppendLine(internalTabs + "<ul>");

            //Files
            strb.AppendLine(internalTabs + "<h3>Files</h3>");

            //Write file
            strb.AppendLine(internalTabs + "<li>");

            strb.AppendLine(internalTabs + "<ol>");
            foreach (ObjectsCore.File file in directory.Files)
            {
                strb.AppendLine(WriteFiletoHTML(file, deepCounterToUse + 2));
            }
            strb.AppendLine(internalTabs + "</ol>");
            strb.AppendLine(internalTabs + "</li>");

            //Sub directories
            strb.AppendLine(internalTabs + "<h3>Sub-Directories</h3>");
            //Write file
            foreach (ObjectsCore.Directory subDirectory in directory.SubDirectories)
            {
                strb.AppendLine(WriteDirectoryToHTML(subDirectory, (deepCounterToUse + 2)));
            }

            strb.AppendLine(internalTabs + "</ul>");

            strb.AppendLine(tabs + "</div>");
            strb.AppendLine(internalTabs + "</li>");

            return strb.ToString(); // do not trim
        }

        /// <summary>
        /// Write an file to HTML
        /// </summary>
        /// <param name="file"></param>
        /// <param name="deepCounter"></param>
        /// <returns></returns>
        private static string WriteFiletoHTML(ObjectsCore.File file, int deepCounter)
        {
            string tabs = new String('\t', deepCounter);

            StringBuilder strb = new StringBuilder();

            strb.AppendLine(tabs + "<li>");
            strb.AppendLine(tabs + "<div class=\"file\">");

            strb.AppendLine(tabs + "<h4>" + file.FileInformation.Name + "</h4>");

            strb.AppendLine(tabs + "<h5>Properties</h5>");

            foreach (Property property in file.PropertyCollection)
            {
                if (property != null)
                {
                    strb.AppendLine(tabs + string.Format(CultureInfo.CurrentCulture, property.Name, property.Value.ToString()));
                }
            }

            strb.AppendLine(tabs + "</div>");
            strb.AppendLine(tabs + "</li>");

            return strb.ToString(); //do not trim
        }

        #endregion

        #region XML

        /// <summary>
        /// Save directory to XML
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePath"></param>
        public static void SaveToXML(ObjectsCore.Directory directory, string filePath)
        {
            XDocument document = new XDocument();

            XElement hdlgElement = new XElement("HDLG");

            XElement elementDirectory = WriteDirectoryToXML(directory);
            hdlgElement.Add(elementDirectory);

            document.Add(hdlgElement);

            //Set settings
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.Unicode,
                Indent = true,
                IndentChars = "  "
            };

            //Write data
            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                document.WriteTo(writer);
                writer.Flush();
            }
        }

        /// <summary>
        /// Write a directory
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static XElement WriteDirectoryToXML(ObjectsCore.Directory directory)
        {
            XElement elementDirectory = new XElement("Directory");

            XAttribute attributeName = new XAttribute("Name", directory.DirectoryInformation.Name);
            elementDirectory.Add(attributeName);

            XElement elementFullName = new XElement("FullName", directory.DirectoryInformation.FullName);
            elementDirectory.Add(elementFullName);

            XElement elementDirectories = new XElement("Directories");
            //Sub directories
            if (directory.SubDirectories.Count > 0)
            {
                foreach (ObjectsCore.Directory subDirectory in directory.SubDirectories)
                {
                    if (subDirectory != null)
                    {
                        XElement elementSubDirectory = WriteDirectoryToXML(subDirectory);
                        elementDirectories.Add(elementSubDirectory);
                    }
                }
            }
            elementDirectory.Add(elementDirectories);

            XElement elementFiles = new XElement("Files");
            //Files
            if (directory.Files.Count > 0)
            {
                foreach (ObjectsCore.File file in directory.Files)
                {
                    if (file != null)
                    {
                        XElement fileElement = WriteFileToXML(file);
                        elementFiles.Add(fileElement);
                    }
                }
            }
            elementDirectory.Add(elementFiles);


            //Return
            return elementDirectory;
        }

        /// <summary>
        /// Write a file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static XElement WriteFileToXML(ObjectsCore.File file)
        {
            XElement elementFile = new XElement("File");
            XAttribute attributeName = new XAttribute("Name", file.FileInformation.Name);
            elementFile.Add(attributeName);

            XElement elementFullName = new XElement("FullName", file.FileInformation.FullName);
            elementFile.Add(elementFullName);

            XElement elementProperties = new XElement("Properties");

            foreach (Property property in file.PropertyCollection)
            {
                if (property != null)
                {
                    XElement elementProperty = new XElement(property.Name, property.Value);
                    elementProperties.Add(elementProperty);
                }
            }

            elementFile.Add(elementProperties);


            return elementFile;
        }

        #endregion
    }
}
