using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using VBIDE = Microsoft.Vbe.Interop;
using System.Reflection;
using System.IO;
using System.Diagnostics;

//https://docs.microsoft.com/zh-tw/visualstudio/vsto/walkthrough-calling-code-from-vba-in-a-visual-csharp-project?view=vs-2022
//https://www.twblogs.net/a/5b8ca4f02b71771883343c57

//https://www.796t.com/post/OXVpaGc=.html
//ExcelApp.ActiveWorkbook.SaveCopyAs(filePath);
//ExcelApp.ActiveWorkbook.Saved = true;
//ExcelApp.Quit();


//https://ithelp.ithome.com.tw/questions/10027673
//oSheet.Range(oSheet.Cells(1,1),oSheet.Cells(1,1)).Formula="=MyDDHHMM(A1)"

namespace csharp_example
{
    class MyProgram
    {
        public static void ex01(String templatefile,String resultfile)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range range;

            if (File.Exists(resultfile))
            {
                File.Delete(resultfile);                
            }
            File.Copy(templatefile, resultfile);

            try
            {
                oXL = new Excel.Application();
                //oXL.Visible = true;

                //excelfile is template excel file
                oWB = (Excel._Workbook)oXL.Workbooks.Open(resultfile);
                oSheet = oWB.Worksheets[1];

                range = oSheet.get_Range("A1:A1");
                //insert the dropdown into the cell
                Excel.Buttons xlButtons = oSheet.Buttons();
                Excel.Button xlButton = xlButtons.Add((double)range.Left, (double)range.Top, (double)range.Width, (double)range.Height);

                //set the name of the new button
                xlButton.Name = "btnDoSomething";
                xlButton.Text = "Click me!";
                xlButton.OnAction = "btnDoSomething_Click";
                buttonMacro(xlButton.Name,oWB);

                //run excel vba
                //oXL.Run("test_autorun");
                //
                //注意要先把檔案copy到D:\Admin\Documents\USIToolV00_0101.xlam才能正確執行到
                oXL.Run("USIToolV00_0101.xlam!test_autorun");


                //https://dotblogs.com.tw/killysss/2015/10/01/153471
                oWB.Save();
                oWB.Close();                
                releaseObject(oWB);
                releaseObject(oXL);
            }
            catch (Exception ex)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                Console.WriteLine($"Error:{errorMessage}");
            }
        }
        private static void buttonMacro(String buttonName, Excel._Workbook oWB)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Sub " + buttonName + "_Click()" + "\n");
            sb.Append("\t" + "msgbox \"" + buttonName + "\"\n");  //add your custom vba code here
            sb.Append("End Sub");
            VBIDE.VBComponent xlModule = oWB.VBProject.VBComponents.Add(VBIDE.vbext_ComponentType.vbext_ct_StdModule);
            xlModule.CodeModule.AddFromString(sb.ToString());
        }
        //~~> Release the objects
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                Console.WriteLine($"Error:{errorMessage}");                
            }
            finally
            {
                GC.Collect();
            }
        }

        //https://stackoverflow.com/questions/9316141/kill-process-excel-c-sharp
        public static  void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")      
            select p;
            foreach (var process in processes)
            {
                if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName)
                    process.Kill();
            }
        }
        //kill all excel process
        public static void KillAllExcelProcess()
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;
            foreach (var process in processes)
            {
                process.Kill();
            }
        }
    }
    public class MyProgramTester
    {
        public void Main()
        {
            String excel_template_file = @"D:\gitWork\0316-testexcel\test.xlsm";
            String excel_result_file = @"D:\gitWork\0316-testexcel\test-result.xlsm";
            MyProgram.ex01(excel_template_file, excel_result_file);

            //MyProgram.KillSpecificExcelFileProcess("USIToolV00_0101.xlam");
            //執行完USIToolV00_0101.xlam會被excel佔用，要先把excel process刪除，查看名再是空的
            MyProgram.KillAllExcelProcess();
        }
    }
}
