using System.Xml;

namespace FetchAWSData
{
    interface IExportAsXml
    {
        void ExportAsExm(XmlDocument document, string[] urlArray, int i, string destinationPath);
    }
}
