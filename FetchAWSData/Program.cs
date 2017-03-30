using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Configuration;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace FetchAWSData
{
    class Program
    {

        static void Main()
        {
            List<string> awsUrl = new List<string>();
            string urlFile = ConfigurationManager.AppSettings["TargetUrlFile"];
            string destinationPath = ConfigurationManager.AppSettings["outPutFilePath"];
            Console.WriteLine("Extracting Data, Might Take Some Time \n");
            IFetchFiles fetchAwsFiles = new FetchFiles();

            //ds--fetch xml aws urls from TargetUrlFile
            using (var reader = new StreamReader(urlFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    awsUrl.Add(line);
                }
            }

            //ds--store all the urls as an array
            string[] urlArray = awsUrl.ToArray();
            
            //ds--fetch all aws data in a new excel
            fetchAwsFiles.FetchData(urlArray, destinationPath);

            //ds--Also can call IXport as XML class to save as an XML
            Console.WriteLine("\n \nProcess Complete");
            Console.ReadKey();
            }
       
    }
}
