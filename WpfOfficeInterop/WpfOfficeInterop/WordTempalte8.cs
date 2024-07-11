using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace WpfOfficeInterop
{
    public class WordTempalte8
    {
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {
                string docxFile = @"D:\template8.docx";
                if (!CreatTable(ref strRet, docxFile))
                    throw new Exception(strRet);

                string pngFile = @"D:\template1.png";
                InsertAPicture(docxFile, pngFile);

                Console.WriteLine("Document... Converted!");
            }
            catch (Exception ex)
            {
                flag = false;
                strRet = string.Format("[Test] {0}", ex.Message);
            }
            return flag;
        }

        //https://learn.microsoft.com/en-us/office/open-xml/word/how-to-add-tables-to-word-processing-documents?tabs=cs-0%2Ccs-1%2Ccs-2%2Ccs-3%2Ccs-4%2Ccs-5%2Ccs-6%2Ccs-7%2Ccs-8%2Ccs
        public static bool CreatTable(ref string strRet,string wfile)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {
                string[,] data = new string[4, 2]
                {
                    {"Summary Test Result", "R0C1"},
                    {"Test Regulation/Standard", "Result(Pass/Fail)"},
                    {"EN300 328 1GHz~18GHz Tx Emission Report", "Pass"},
                    {"EN301 893 1GHz~26.5GHz Tx Emission Report", "Pass"}
                };

                using (var document = WordprocessingDocument.Open(wfile, true))
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

                    for (var i = 0; i < 4; i++)
                    {
                        var tr = new TableRow();
                        for (var j = 0; j < 2; j++)
                        {
                            var tc = new TableCell();

                            //https://stackoverflow.com/questions/18025424/c-sharp-openxml-word-table-autofit-to-window
                            //https://blog.darkthread.net/blog/openxml-word-table-example/
                            if (j == 0)
                            {
                                tc.Append(new TableCellProperties(
                                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "80" }));
                            }
                            else
                            {
                                tc.Append(new TableCellProperties(
                                    new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "20" }));
                            }
                            string txt = data[i,j];
                            tc.Append(new Paragraph(new Run(new Text(txt))));


                            // Assume you want columns that are automatically sized.                            
                            //tc.Append(new TableCellProperties(
                                //new TableCellWidth { Type = TableWidthUnitValues.Auto }));

                            if (i == 0)
                            {
                                //https://stackoverflow.com/questions/49638852/how-i-can-merge-microsoft-word-table-cells-horizontally-using-openxml-c-sharp
                                if (j ==0)
                                {
                                    TableCellProperties cellOneProperties = new TableCellProperties();
                                    cellOneProperties.Append(new HorizontalMerge()
                                    {
                                        Val = MergedCellValues.Restart
                                    });
                                    tc.Append(cellOneProperties);
                                }
                                else
                                {
                                    TableCellProperties cellTwoProperties = new TableCellProperties();
                                    cellTwoProperties.Append(new HorizontalMerge()
                                    {
                                        Val = MergedCellValues.Continue
                                    });
                                    tc.Append(cellTwoProperties);
                                }
                            }
                            
                            tr.Append(tc);
                        }
                        table.Append(tr);
                    }
                    doc.Body.Append(table);
                    doc.Save();
                }
            }
            catch(Exception ex)
            {
                flag = false;
                strRet = string.Format("[CreatTable] {0}", ex.Message);
            }
            return flag;
        }

        //https://learn.microsoft.com/en-us/office/open-xml/word/how-to-insert-a-picture-into-a-word-processing-document?tabs=cs-0%2Ccs-1%2Ccs-2%2Ccs-3%2Ccs
        public static void InsertAPicture(string document, string fileName)
        {
            using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(document, true))
            {
                if (wordprocessingDocument.MainDocumentPart is null)
                {
                    throw new ArgumentNullException("MainDocumentPart is null.");
                }

                MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;

                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }

                AddImageToBody(wordprocessingDocument, mainPart.GetIdOfPart(imagePart));
            }
        }

        static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 990000L, Cy = 792000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            if (wordDoc.MainDocumentPart is null || wordDoc.MainDocumentPart.Document.Body is null)
            {
                throw new ArgumentNullException("MainDocumentPart and/or Body is null.");
            }

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }
    }
}
