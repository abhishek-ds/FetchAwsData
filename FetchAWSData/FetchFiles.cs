﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;

namespace FetchAWSData
{
    class FetchFiles 
    {
        public void FetchData(string[] urlArray, string destinationPath)
        {
            WebClient client = new WebClient();
            DataSet dataSet = new DataSet();
            Application excel = new Application();
            XmlToExcelConverter excelConverter = new XmlToExcelConverter();
            XmlDocument document = new XmlDocument();

            for (int i = 0; i < urlArray.Length; i++)
            {
                Stream stream = client.OpenRead(urlArray[i]);
                dataSet.ReadXml(stream);
                Workbook workBook = excel.Workbooks.Add(true);

                // ds--Calling Excel Converter to save as a workbook
                foreach (System.Data.DataTable dataTable in dataSet.Tables)
                {
                    excelConverter.ExportToExcel(dataTable, excel, workBook);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Processing File Number {0} ", i + 1);
                }

                workBook.SaveAs(destinationPath + i);
                releaseObject(workBook);                             
            }
            excel.Quit();
            releaseObject(excel);
        }
        
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }

            catch (Exception ex)
            {
                obj = null;
            }

            finally
            {
                GC.Collect();
            }
        }
    }
}