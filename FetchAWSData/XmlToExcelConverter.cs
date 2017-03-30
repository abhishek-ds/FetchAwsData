using Microsoft.Office.Interop.Excel;
using System.Data;


namespace FetchAWSData
{
    class XmlToExcelConverter : IXmlToExcelConverter
    {
        public void ExportToExcel(System.Data.DataTable dataTable, Application excel, Workbook workBook)
        {
            Worksheet workSheet = workBook.ActiveSheet;
            int Column = workSheet.UsedRange.Columns.Count - 1;
            int Column1 = Column;
            int Column2 = Column;

            foreach (DataColumn dc in dataTable.Columns)
            {
                Column++;
                excel.Cells[1, Column] = dc.ColumnName;
            }

            foreach (DataRow datarow in dataTable.Rows)
            {
                int mainRow = 0;
                mainRow++;
                           
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    Column1++;
                    excel.Cells[mainRow + 1, Column1] = datarow[dataColumn.ColumnName];
                }

                Column1 = Column2;
            }

            workSheet.Activate();
        }
    }
}
