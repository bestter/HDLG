using HDLG.SharedInterface;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;

namespace HDLG.ImagesPlugin
{
    public class JpegPlugin : IPlugin
    {
        // <summary>
        /// Get list of supported extensions
        /// </summary>
        /// <returns></returns>
        public string[] GetSupportedExtensions()
        {
            return new string[] { ".jpg", ".jpeg", ".jpe" };
        }

        /// <summary>
        /// Get Jpeg properties
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public PropertyCollection GetProperties(System.IO.FileInfo file)
        {
            PropertyCollection properties = new PropertyCollection();

            if (GetSupportedExtensions().Contains(file.Extension))
            {
                // Create an Image object. 
                Image image = new Bitmap(file.FullName);

                // Get the PropertyItems property from image.
                PropertyItem[] propItems = image.PropertyItems;

                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

                foreach (PropertyItem propItem in propItems)
                {
                    string name = null;
                    object value = null;


                    switch (propItem.Id)
                    {
                        case 271:
                            name = "Equipment manufacturer"; //Manufacturer
                            value = encoding.GetString(propItem.Value);
                            break;
                        case 272:
                            name = "Equipment model"; //Model
                            value = encoding.GetString(propItem.Value);
                            break;
                        case 800:
                            name = "Title"; //Title
                            value = encoding.GetString(propItem.Value);
                            break;
                        default:
                            name = propItem.Id.ToString();
                            value = propItem.Value.ToString();
                            break;
                    }
                    //properties.Add(propItem.i)

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        properties.Add(name, value);
                    }
                }
            }
            else
            {
                throw new WrongFileFormatException(string.Format(CultureInfo.CurrentCulture, "File extension {0} is not supported by plugin {1}", file.Extension, this.GetType().Name));
            }


            return properties;
        }
    }
}
