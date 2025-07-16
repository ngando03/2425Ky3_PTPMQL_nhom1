
//using OfficeOpenXml;
//using System.Data;
//using System.IO;

//namespace DemoMVC.Models.Process
//{
//    public class ExcelProcess
//    {
//        public DataTable ExcelToDataTable(string filePath)
//        {
//            var dt = new DataTable();
//            FileInfo fileInfo = new FileInfo(filePath);
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//            using (ExcelPackage package = new ExcelPackage(fileInfo))
//            {
//                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // sheet đầu tiên

//                // Lấy số cột và dòng
//                int rowCount = worksheet.Dimension.Rows;
//                int colCount = worksheet.Dimension.Columns;

//                // Tạo tiêu đề cột từ dòng đầu tiên
//                for (int col = 1; col <= colCount; col++)
//                {
//                    new DataTable().Columns.Add(worksheet.Cells[1, col].Text);
//                }

//                // Lấy dữ liệu từ dòng 2 trở đi
//                for (int row = 2; row <= rowCount; row++)
//                {
//                    DataRow dr = new DataTable().NewRow();
//                    for (int col = 1; col <= colCount; col++)
//                    {
//                        dr[col - 1] = worksheet.Cells[row, col].Text;
//                    }
//                    new DataTable().Rows.Add(dr);
//                }

//                return new DataTable();
//            }
//        }
//    }
//}
using OfficeOpenXml;
using System.Data;
using System.IO;

internal class ExcelProcess
{
    public DataTable ExcelToDataTable(string fileLocation)
    {
        var dataTable = new DataTable();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Quan trọng!
        using (var package = new ExcelPackage(new FileInfo(fileLocation)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Sheet đầu tiên
            int colCount = worksheet.Dimension.End.Column;
            int rowCount = worksheet.Dimension.End.Row;

            // Thêm cột (lấy từ dòng đầu tiên)
            for (int col = 1; col <= colCount; col++)
            {
                dataTable.Columns.Add(worksheet.Cells[1, col].Text);
            }

            // Thêm dòng (từ dòng 2 trở đi)
            for (int row = 2; row <= rowCount; row++)
            {
                DataRow dr = dataTable.NewRow();
                for (int col = 1; col <= colCount; col++)
                {
                    dr[col - 1] = worksheet.Cells[row, col].Text;
                }
                dataTable.Rows.Add(dr);
            }
        }

        return dataTable;
    }
}