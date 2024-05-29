using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOfficeInterop
{
    public class WordTemplate4
    {
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {
                var outFile = "d:\\template4Out.docx";
                //CreateWordDoc(outFile, "Test11");
                outFile = "d:\\template22Out.docx";
                AddTable(outFile);
            }
            catch(Exception ex)
            {
                flag = true;
                strRet = string.Format("[] {0}", ex.Message);
            }
            return flag;
        }

        //https://learn.microsoft.com/en-us/office/open-xml/word/structure-of-a-wordprocessingml-document?tabs=cs
        private static void CreateWordDoc(string filepath, string msg)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(filepath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = doc.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());

                // String msg contains the text, "Hello, Word!"
                run.AppendChild(new Text(msg));
            }
        }
        //https://blog.poychang.net/csharp-9-check-for-null-or-not/
        //C# 9.0  if (name is not null) { } => C#7.3 if (name is object) { }

        //https://ittranslator.cn/dotnet/csharp/2021/01/11/null-forgiving-operator.html
        //若定義非null , string str1,..之遇到str1 = null..此時build會有error (加上!)可以去除error

        //https://learn.microsoft.com/en-us/office/open-xml/word/how-to-add-tables-to-word-processing-documents?tabs=cs-0%2Ccs-1%2Ccs-2%2Ccs-3%2Ccs-4%2Ccs-5%2Ccs-6%2Ccs-7%2Ccs-8%2Ccs
        // Take the data from a two-dimensional array and build a table at the 
        // end of the supplied document.

        public class ClsTable
        {
            public string[] Row1 { get; set; }
        }

        static void AddTable(string fileName)
        {
            string[,] data = new string[3,3]
            {
                {"R1C1", "R1C2", "R1C3"},
                {"R2C1", "R2C2", "R2C3"},
                {"R3C1", "R3C2", "R3C3"}
            };

            if (data is object)
            {
                using (var document = WordprocessingDocument.Open(fileName, true))
                {
                    if (document.MainDocumentPart is null || document.MainDocumentPart.Document.Body is null)
                    {
                        throw new ArgumentNullException("MainDocumentPart and/or Body is null.");
                    }

                    var doc = document.MainDocumentPart.Document;

                    Table table = new Table();

                    TableProperties props = new TableProperties(
                        new TableBorders(
                        new TopBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new BottomBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new LeftBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new RightBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new InsideHorizontalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        },
                        new InsideVerticalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        }));

                    table.AppendChild<TableProperties>(props);
                    for (var i = 0; i < 3; i++)
                    {
                        var tr = new TableRow();
                        for (var j = 0; j < 3; j++)
                        {
                            var tc = new TableCell();
                            tc.Append(new Paragraph(new Run(new Text(data[i,j]))));

                            // Assume you want columns that are automatically sized.
                            tc.Append(new TableCellProperties(
                                new TableCellWidth { Type = TableWidthUnitValues.Auto }));

                            tr.Append(tc);
                        }
                        table.Append(tr);
                    }

                    doc.Body.Append(table);
                    doc.Save();
                }
            }
        }
    }
}
