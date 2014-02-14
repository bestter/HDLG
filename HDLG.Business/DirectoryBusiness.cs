using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HDLG.Objects;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using HtmlAgilityPack;


namespace HDLG.Business
{
	public static class DirectoryBusiness
	{
		
		public static HDLG.Objects.Directory GetDirectoryInformation(string directoryPath)
		{
			if (string.IsNullOrEmpty(directoryPath))
			{
				throw new ArgumentNullException("directoryPath");
			}

			DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
			
			return LoadDirectory(directoryInfo);
		}

		/// <summary>
		/// Create a new DirectoryBusiness
		/// </summary>
		/// <param name="directoryInfo">Directory to </param>
		public static HDLG.Objects.Directory GetDirectoryInformation(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null)
			{
				throw new ArgumentNullException("directory");
			}
			
			return LoadDirectory(directoryInfo);
		}

		/// <summary>
		/// Init directory
		/// </summary>
		private static Objects.Directory LoadDirectory(DirectoryInfo directoryInfo)
		{
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, "Directory {0} do not exist", directoryInfo.FullName));
			}

			//Get files
			System.IO.FileInfo[] filesInfos = new FileInfo[1];
			try
			{
				filesInfos = directoryInfo.GetFiles();
			}
			catch
			{
			}
			
			FileCollection Files = new FileCollection();
			//Get properties
			foreach (FileInfo fileInfo in filesInfos)
			{
				if (fileInfo != null)
				{
					//Get properties

					//Add file
					Files.Add(new Objects.File(fileInfo, new Property[1]));
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
					Directories.Add(DirectoryBusiness.GetDirectoryInformation(di));
				}				
			}
			//Sort
			Directories.Sort();

			//Create directory
			Objects.Directory directory = new Objects.Directory(directoryInfo, Files, Directories);            

			return directory;
		}

		#region HTML
		
		/// <summary>
		/// Save directory to HTML
		/// </summary>
		/// <param name="directory"></param>
		/// <param name="filePath"></param>
		public static void SaveToHtml(HDLG.Objects.Directory directory, string filePath)
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
			workFile = workFile.Replace("</body>", string.Format(CultureInfo.CurrentCulture, "{0}{1}</body>", strb.ToString().Trim(), System.Environment.NewLine));


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
		private static string WriteDirectoryToHTML(HDLG.Objects.Directory directory, int deepCounter)
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
			foreach (HDLG.Objects.File file in directory.Files)
			{
				strb.AppendLine(WriteFiletoHTML(file, deepCounterToUse + 2));
			}
			strb.AppendLine(internalTabs + "</ol>");
			strb.AppendLine(internalTabs + "</li>");

			//Sub directories
			strb.AppendLine(internalTabs + "<h3>Sub-Directories</h3>");
			//Write file
			foreach (HDLG.Objects.Directory subDirectory in directory.SubDirectories)
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
		private static string WriteFiletoHTML(HDLG.Objects.File file, int deepCounter)
		{
			string tabs = new String('\t', deepCounter);

			StringBuilder strb = new StringBuilder();

			strb.AppendLine(tabs + "<li>");
			strb.AppendLine(tabs + "<div class=\"file\">");

			strb.AppendLine(tabs + "<h4>" + file.FileInformation.Name + "</h4>");

			strb.AppendLine(tabs + "<h5>Properties</h5>");

			foreach (HDLG.Objects.Property property in file.PropertyCollection)
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
		public static void SaveToXML(HDLG.Objects.Directory directory, string filePath)
		{
			XDocument document = new XDocument();

			XElement hdlgElement = new XElement("HDLG");

			XElement elementDirectory = WriteDirectoryToXML(directory);
			hdlgElement.Add(elementDirectory);

			document.Add(hdlgElement);

			//Set settings
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Encoding = System.Text.Encoding.Unicode;
			settings.Indent = true;
			settings.IndentChars = "  ";

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
		private static XElement WriteDirectoryToXML(HDLG.Objects.Directory directory)
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
				foreach (HDLG.Objects.Directory subDirectory in directory.SubDirectories)
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
				foreach (HDLG.Objects.File file in directory.Files)
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
		private static XElement WriteFileToXML(HDLG.Objects.File file)
		{
			XElement elementFile = new XElement("File");
			XAttribute attributeName = new XAttribute("Name", file.FileInformation.Name);
			elementFile.Add(attributeName);

			XElement elementFullName = new XElement("FullName", file.FileInformation.FullName);
			elementFile.Add(elementFullName);

			XElement elementProperties = new XElement("Properties");

			foreach (HDLG.Objects.Property property in file.PropertyCollection)
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
