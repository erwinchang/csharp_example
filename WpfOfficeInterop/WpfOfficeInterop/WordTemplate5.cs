using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOfficeInterop
{
    public class WordTemplate5
    {
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {
                var outFile = "d:\\template22.docx";
                ChangeTextInCell(outFile, "test11");
            }
            catch(Exception ex)
            {
                flag = false;
                strRet = string.Format("[Test] {0}", ex.Message);
            }
            return flag;
        }

        //https://learn.microsoft.com/en-us/office/open-xml/word/how-to-change-text-in-a-table-in-a-word-processing-document?tabs=cs-0%2Ccs-1%2Ccs-2%2Ccs-3%2Ccs
        // Change the text in a table in a word processing document.
        static void ChangeTextInCell(string filePath, string txt)
        {
            // Use the file name and path passed in as an argument to 
            // open an existing document.            
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                if (doc.MainDocumentPart is null || doc.MainDocumentPart.Document.Body is null)
                {
                    throw new ArgumentNullException("MainDocumentPart and/or Body is null.");
                }

                // Find the first table in the document.
                Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().First();

                // Find the second row in the table.
                //TableRow row = table.Elements<TableRow>().ElementAt(1);

                // Find the third cell in the row.
                //TableCell cell = row.Elements<TableCell>().ElementAt(2);

                // Find the first paragraph in the table cell.
                //Paragraph p = cell.Elements<Paragraph>().First();

                // Find the first run in the paragraph.
                //Run r = p.Elements<Run>().First();

                // Set the text for the run.
                //Text t = r.Elements<Text>().First();
                //t.Text = txt;

                /*
                 * No #	Frequency
(MHz)	Emission
(dBuV/m)	Limit
(dBuV/m)	Margin
(dB)	No #	Frequency
(MHz)	Emission
(dBuV/m)	Limit
(dBuV/m)	Margin
(dB)
R0C0	R0C1	R0C2	R0C3	R0C4	R0C5	R0C6	R0C7	R0C8	R0C9	R0C10	R0C11
R1C0	R1C1	R1C2	R1C3	R1C4	R1C5	R1C6	R1C7	R1C8	R1C9	R1C10	R1C11
R2C0	R2C1	R2C2	R2C3	R2C4	R2C5	R2C6	R2C7	R2C8	R2C9	R2C10	R2C11
R3C0	R3C1	R3C2	R3C3	R3C4	R3C5	R3C6	R3C7	R3C8	R3C9	R3C10	R3C11
R4C0	R4C1	R4C2	R4C3	R4C4	R4C5	R4C6	R4C7	R4C8	R4C9	R4C10	R4C11
R5C0	R5C1	R5C2	R5C3	R5C4	R5C5	R5C6	R5C7	R5C8	R5C9	R5C10	R5C11
R6C0	R6C1	R6C2	R6C3	R6C4	R6C5	R6C6	R6C7	R6C8	R6C9	R6C10	R6C11
R7C0	R7C1	R7C2	R7C3	R7C4	R7C5	R7C6	R7C7	R7C8	R7C9	R7C10	R7C11
R8C0	R8C1	R8C2	R8C3	R8C4	R8C5	R8C6	R8C7	R8C8	R8C9	R8C10	R8C11
R9C0	R9C1	R9C2	R9C3	R9C4	R9C5	R9C6	R9C7	R9C8	R9C9	R9C10	R9C11
R10C0	R10C1	R10C2	R10C3	R10C4	R10C5	R10C6	R10C7	R10C8	R10C9	R10C10	R10C11
R11C0	R11C1	R11C2	R11C3	R11C4	R11C5	R11C6	R11C7	R11C8	R11C9	R11C10	R11C11
R12C0	R12C1	R12C2	R12C3	R12C4	R12C5	R12C6	R12C7	R12C8	R12C9	R12C10	R12C11
R13C0	R13C1	R13C2	R13C3	R13C4	R13C5	R13C6	R13C7	R13C8	R13C9	R13C10	R13C11
                */

                int rowCntMax = 14;
                int colCntMax = 12;
                int iCol = 0;
                int iRow = 0;
                bool bRowStart = false;
                foreach (TableRow row in table.Elements<TableRow>())
                {
                    if (bRowStart && iRow < rowCntMax)
                    {
                        int i = 0;
                        iCol = 0;
                        foreach (TableCell cell in row.Elements<TableCell>())
                        {
                            if (i >= 1 && (i < (1 + colCntMax)))
                            {
                                Paragraph p = cell.Elements<Paragraph>().First();
                                Run r = new Run();
                                Text t = new Text();
                                t.Text = string.Format("R{0}C{1}", iRow, iCol);
                                r.AddChild(t);
                                p.AddChild(r);
                                //Run r = p.Elements<Run>().First();
                                //Text t = r.Elements<Text>().First();
                                iCol++;
                            }
                            i++;
                        }
                        iRow++;
                    }
                    if (row.InnerText.Contains("(MHz)"))
                    {
                        bRowStart = true;
                    }
                }
            }
        }
    }
}
