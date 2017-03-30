using Microsoft.Office.Interop.Excel;


namespace FetchAWSData
{
    interface IXmlToExcelConverter
    {
        void ExportToExcel(System.Data.DataTable dataTable, Application excel, Workbook workBook);
    }
}
