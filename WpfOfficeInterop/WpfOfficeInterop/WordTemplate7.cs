using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace WpfOfficeInterop
{
    public class WordTemplate7
    {
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {
                string docxFile = @"D:\template7_1.docx";
                string pdfFile = @"D:\template7_1.pdf";
                Convert(docxFile,pdfFile, WdSaveFormat.wdFormatPDF);
                Console.WriteLine("Document... Converted!");
            }
            catch (Exception ex)
            {
                flag = false;
                strRet = string.Format("[Test] {0}", ex.Message);
            }
            return flag;
        }
        //https://gist.github.com/ArthurEzenwanne/c443e8bbc67af312aea05c632652ab56
        public static void Convert(string input, string output, WdSaveFormat format)
        {
            // Create an instance of Word.exe
            _Application oWord = new Word.Application
            {
                // Make this instance of word invisible (Can still see it in the taskmgr).
                Visible = false
            };

            // Interop requires objects.
            object oMissing = System.Reflection.Missing.Value;
            object isVisible = true;
            object readOnly = true;     // Does not cause any word dialog to show up
            //object readOnly = false;  // Causes a word object dialog to show at the end of the conversion
            object oInput = input;
            object oOutput = output;
            object oFormat = format;

            // Load a document into our instance of word.exe
            _Document oDoc = oWord.Documents.Open(
                ref oInput, ref oMissing, ref readOnly, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref isVisible, ref oMissing, ref oMissing, ref oMissing, ref oMissing
                );

            // Make this document the active document.
            oDoc.Activate();

            // Save this document using Word
            oDoc.SaveAs(ref oOutput, ref oFormat, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing
                );

            // Always close Word.exe.
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
        }
    }
}
