using System;
using System.IO;
using System.Xml;

namespace FetchAWSData
{
    class ExportAsXml : IExportAsXml
    {
        public void ExportAsExm(XmlDocument document, string[] urlArray, int i, string destinationPath)
        {
            document.Load(urlArray[i]);    
            File.WriteAllText(destinationPath + "File" + i + ".xml", document.InnerXml);
        }
    }
}
