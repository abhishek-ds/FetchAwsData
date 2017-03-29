using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace FetchAWSData
{
    class Program
    {
        static void Main()
        {
            List<string> awsUrl = new List<string>();
            WebClient client = new WebClient();
            using (var reader = new StreamReader(@"C:\Users\Abhishek\Desktop\test.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    awsUrl.Add(line);
                }
            }
            string[] urlArray = awsUrl.ToArray();

            foreach (string x in urlArray)
            {
                XmlDocument document = new XmlDocument();
                document.Load(x);
                File.WriteAllText("", document.InnerXml);
            }
            Console.WriteLine("Process Complete");
            Console.ReadKey();
        }
    }
}
