using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace csharp_example
{

    class MyProgram
    {
        public static void DisplayFunc(Account account, Excel.Range cell)
        {
            cell.Value = account.ID;
            cell.Offset[0, 1].Value = account.Balance;
            if (account.Balance < 0)
            {
                cell.Interior.Color = 255;
                cell.Offset[0, 1].Interior.Color = 255;
            }
        }

        public static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            //var excelApp = this.Application;
            var excelApp = new Excel.Application();

            // Add a new Excel workbook.
            excelApp.Workbooks.Add();
            excelApp.Visible = true;
            excelApp.Range["A1"].Value = "ID";
            excelApp.Range["B1"].Value = "Balance";
            excelApp.Range["A2"].Select();

            foreach (var ac in accounts)
            {
                DisplayFunc(ac, excelApp.ActiveCell);
                excelApp.ActiveCell.Offset[1, 0].Select();
            }
            // Copy the results to the Clipboard.
            excelApp.Range["A1:B3"].Copy();

            excelApp.Columns[1].AutoFit();
            excelApp.Columns[2].AutoFit();
        }
    }
}
