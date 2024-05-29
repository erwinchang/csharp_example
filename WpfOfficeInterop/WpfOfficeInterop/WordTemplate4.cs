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

                //outFile = "d:\\template22Out.docx";
                //AddTable(outFile);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(outFile, true))
                {
                    // Get the first paragraph.
                    Paragraph p =
                      doc.MainDocumentPart.Document.Body.Descendants<Paragraph>()
                      .ElementAtOrDefault(1);

                    // Check for a null reference. 
                    if (p == null)
                    {
                        throw new ArgumentOutOfRangeException("p",
                            "Paragraph was not found.");
                    }

                    ApplyStyleToParagraph(doc, "OverdueAmount", "Overdue Amount", p);
                }
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

        /*
         * 
         * 
         */
        //https://learn.microsoft.com/en-us/office/open-xml/word/how-to-apply-a-style-to-a-paragraph-in-a-word-processing-document?tabs=cs-0%2Ccs-1%2Ccs-2%2Ccs-3%2Ccs-4%2Ccs-5%2Ccs-6%2Ccs-7%2Ccs-8%2Ccs-9%2Ccs-10%2Ccs
        // Apply a style to a paragraph.
        static void ApplyStyleToParagraph(WordprocessingDocument doc, string styleid, string stylename, Paragraph p)
        {
            if (doc is null)
            {
                throw new ArgumentNullException(nameof(doc));
            }
            // If the paragraph has no ParagraphProperties object, create one.
            if (p.Elements<ParagraphProperties>().Count() == 0)
            {
                p.PrependChild<ParagraphProperties>(new ParagraphProperties());
            }

            // Get the paragraph properties element of the paragraph.
            ParagraphProperties pPr = p.Elements<ParagraphProperties>().First();

            // Get the Styles part for this document.
            StyleDefinitionsPart part = doc.MainDocumentPart?.StyleDefinitionsPart;

            // If the Styles part does not exist, add it and then add the style.
            if (part is null)
            {
                part = AddStylesPartToPackage(doc);
                AddNewStyle(part, styleid, stylename);
            }
            else
            {
                // If the style is not in the document, add it.
                if (IsStyleIdInDocument(doc, styleid) != true)
                {
                    // No match on styleid, so let's try style name.
                    string styleidFromName = GetStyleIdFromStyleName(doc, stylename);

                    if (styleidFromName is null)
                    {
                        AddNewStyle(part, styleid, stylename);
                    }
                    else
                        styleid = styleidFromName;
                }
            }

            // Set the style of the paragraph.
            pPr.ParagraphStyleId = new ParagraphStyleId() { Val = styleid };
        }

        // Return true if the style id is in the document, false otherwise.
        static bool IsStyleIdInDocument(WordprocessingDocument doc, string styleid)
        {
            // Get access to the Styles element for this document.
            Styles s = doc.MainDocumentPart?.StyleDefinitionsPart?.Styles;

            if (s is null)
            {
                return false;
            }

            // Check that there are styles and how many.
            int n = s.Elements<Style>().Count();

            if (n == 0)
            {
                return false;
            }

            // Look for a match on styleid.
            Style style = s.Elements<Style>()
                .Where(st => (st.StyleId is object && st.StyleId == styleid) && (st.Type is object && st.Type == StyleValues.Paragraph))
                .FirstOrDefault();
            if (style is null)
            {
                return false;
            }

            return true;
        }

        // Return styleid that matches the styleName, or null when there's no match.
        static string GetStyleIdFromStyleName(WordprocessingDocument doc, string styleName)
        {
            StyleDefinitionsPart stylePart = doc.MainDocumentPart?.StyleDefinitionsPart;
            string styleId = stylePart.Styles.Descendants<StyleName>()
                .Where(s =>
                {
                    OpenXmlElement p = s.Parent;
                    EnumValue<StyleValues> styleValue = p is null ? null : ((Style)p).Type;

                    return s.Val is object && s.Val.Value is object && s.Val.Value.Equals(styleName) &&
                    (styleValue is object && styleValue == StyleValues.Paragraph);
                })
                .Select(n =>
                {

                    OpenXmlElement p = n.Parent;
                    return p is null ? null : ((Style)p).StyleId;
                }).FirstOrDefault();

            return styleId;
        }

        // Create a new style with the specified styleid and stylename and add it to the specified
        // style definitions part.
        static void AddNewStyle(StyleDefinitionsPart styleDefinitionsPart, string styleid, string stylename)
        {
            // Get access to the root element of the styles part.
            styleDefinitionsPart.Styles = new Styles();
            Styles styles = styleDefinitionsPart.Styles;

            // Create a new paragraph style and specify some of the properties.
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = styleid,
                CustomStyle = true
            };
            StyleName styleName1 = new StyleName() { Val = stylename };
            BasedOn basedOn1 = new BasedOn() { Val = "Normal" };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normal" };
            style.Append(styleName1);
            style.Append(basedOn1);
            style.Append(nextParagraphStyle1);

            // Create the StyleRunProperties object and specify some of the run properties.
            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            Bold bold1 = new Bold();
            Color color1 = new Color() { ThemeColor = ThemeColorValues.Accent2 };
            RunFonts font1 = new RunFonts() { Ascii = "Lucida Console" };
            Italic italic1 = new Italic();
            // Specify a 12 point size.
            FontSize fontSize1 = new FontSize() { Val = "24" };
            styleRunProperties1.Append(bold1);
            styleRunProperties1.Append(color1);
            styleRunProperties1.Append(font1);
            styleRunProperties1.Append(fontSize1);
            styleRunProperties1.Append(italic1);

            // Add the run properties to the style.
            style.Append(styleRunProperties1);

            // Add the style to the styles part.
            styles.Append(style);
        }

        // Add a StylesDefinitionsPart to the document.  Returns a reference to it.
        static StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            MainDocumentPart mainDocumentPart = doc.MainDocumentPart ?? doc.AddMainDocumentPart();
            StyleDefinitionsPart part = mainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new Styles();
            root.Save(part);

            return part;
        }
    }
}
