using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace csharp_example
{
    class MyProgram
    {
        public static void OpenExcel(String filename)
        {
            //https://www.796t.com/post/OXM2cnU=.html
            //https://docs.microsoft.com/zh-tw/previous-versions/office/troubleshoot/office-developer/automate-excel-from-visual-c
            Excel.Application oXL;
            Excel._Workbook oWB;
            //Excel._Worksheet oSheet;

            //https://stackoverflow.com/questions/40231061/how-to-open-workbook-by-filename-without-displaying-excel-window
            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;

                oWB = (Excel._Workbook) oXL.Workbooks.Open(filename);
                //oWB = (Excel._Workbook) oXL.Workbooks.Open(filename, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                foreach(Excel._Worksheet oSheet1 in oWB.Worksheets)
                {
                    String sheetName = oSheet1.Name;
                    Console.WriteLine($"name:{sheetName}");

                    //if (String.Equals(sheetName, "History") == true)
                    if (String.Equals(sheetName, "Wifi_2G_TX_B mode") == true)
                    {
                        Console.WriteLine($"name:{sheetName} => write data");
                        oSheet1.Cells[1, 1] = "First Name";
                        oSheet1.Cells[1, 2] = "Last Name";
                        oSheet1.Cells[1, 3] = "Full Name";
                        oSheet1.Cells[1, 4] = "Salary";
                    }

                }                
                //oWB.Close();
                //oXL.Quit();
            }
            catch(Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                Console.WriteLine($"Error:{errorMessage}");
            }
        }
    }
}
