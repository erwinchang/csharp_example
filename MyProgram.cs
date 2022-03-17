using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using VBIDE = Microsoft.Vbe.Interop;
using System.Reflection;

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
        public static void ex01(String excelfile)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range range;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;

                //excelfile is template excel file
                oWB = (Excel._Workbook)oXL.Workbooks.Open(excelfile);
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

                //https://social.msdn.microsoft.com/Forums/lync/en-US/2e33b8e5-c9fd-42a1-8d67-3d61d2cedc1c/how-to-call-excel-macros-programmatically-in-c?forum=exceldev
                oXL.Run("ShowMsg", "Hello from C# Client", "Demo to run Excel macros from C#");
                //oXL.Run("btnDoSomething_Click");
                String tt = "11";
                //oWB.Close();
                //oXL.Quit();
                //releaseObject(oXL);
                //releaseObject(oWB);

                //execfile2 = excelfile +  vba code 
                //String execfile2 = @"D:\gitWork\0316-testexcel\test99.xlsm";
                //oXL.ActiveWorkbook.SaveCopyAs(execfile2);
                //oXL.ActiveWorkbook.Saved = true;
                //oXL.ActiveWorkbook.Close();
                //oXL.Quit();
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
            }
            finally
            {
                GC.Collect();
            }
        }
    }
    public class MyProgramTester
    {
        public void Main()
        {
            String execfile = @"D:\gitWork\0316-testexcel\test.xlsm";
            MyProgram.ex01(execfile);
        }
    }
}
