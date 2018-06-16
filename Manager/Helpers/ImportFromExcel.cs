using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpreadsheetLight;
using System.IO;
using OfficeOpenXml;
using System.Text;
using Manager.API_Controllers.Models;

namespace Manager.Helpers
{
    public class ImportFromExcel
    {
        public List<Stock> ReadExcel(string filePath)
        {
            FileInfo file = new FileInfo(Path.Combine(filePath));
            try
            {
                var stockList = new List<Stock>();
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        if (row != 1)
                        {
                            var data = new Stock();
                            data.stockName = worksheet.Cells[row, 1].Value.ToString();
                            data.quantity = float.Parse(worksheet.Cells[row, 2].Value.ToString());
                            data.avgPrice = float.Parse(worksheet.Cells[row, 3].Value.ToString());
                            data.currentSharePrice = float.Parse(worksheet.Cells[row, 4].Value.ToString());
                            stockList.Add(data);
                        }
                    }
                    return stockList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
