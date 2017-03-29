using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Configuration;

namespace FetchAWSData
{
    class Program
    {
        
        static void Main()
        {
            List<string> awsUrl = new List<string>();
            WebClient client = new WebClient();
            string urlFile = ConfigurationManager.AppSettings["TargetUrlFile"];
            string destinationPath = ConfigurationManager.AppSettings["outPutFilePath"];
            Console.WriteLine("Extracting Data, Might Take Some Time \n");
            using (var reader = new StreamReader(urlFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    awsUrl.Add(line);
                }
            }
            string[] urlArray = awsUrl.ToArray();

            for(int i=0; i< urlArray.Length; i++)
            {
                XmlDocument document = new XmlDocument();
                document.Load(urlArray[i]);    
                File.WriteAllText(destinationPath + "File" + i + ".xml", document.InnerXml);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("Processing File Number {0} ", i+1);
            }
            Console.WriteLine("\n \n Process Complete");
            Console.ReadKey();
        }
    }
}
