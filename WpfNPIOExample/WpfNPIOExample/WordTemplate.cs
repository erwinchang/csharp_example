using NPOI.Util;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNPIOExample
{
    public class WordTemplate
    {
        public static void Test()
        {
            string strImgPath = ".\\DBmPlot.png";
            FileStream fs = new FileStream(strImgPath, FileMode.Open, FileAccess.Read);
            var template = ".\\model.docx";
            var outPath = ".\\outPath.docx";
            using(FileStream stream = new FileStream(template, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XWPFDocument doc = new XWPFDocument(stream);
                Dictionary<string, string> data = new Dictionary<string, string>
                {
                    {"$[lqwvje]$","罗分明" }
                };
                UpStr(doc, data);
                UpImage(doc, fs, "$[image]$", Units.PixelToEMU(758), Units.PixelToEMU(374));
                using (FileStream stream2 = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    doc.Write(stream2);
                }
                doc.Dispose();
            }
        }

        public static void UpStr(XWPFDocument doc, Dictionary<string, string> data)
        {
            if (doc == null || data == null || data.Count < 1)
            {
                return;
            }
            foreach (XWPFTable table in doc.Tables)//遍历所有表格数据
            {
                foreach (XWPFTableRow row in table.Rows)
                {
                    foreach (XWPFTableCell cell in row.GetTableICells())
                    {

                        foreach (var para in cell.Paragraphs)
                        {
                            string oldText = para.ParagraphText;
                            foreach (KeyValuePair<string, string> kv in data)
                            {
                                if (oldText.Contains(kv.Key))
                                {
                                    para.ReplaceText(kv.Key, kv.Value);
                                }
                            }
                        }
                    }
                }
            }

            foreach (var para in doc.Paragraphs)//遍历所有表格以外的数据
            {
                string oldText = para.ParagraphText;
                foreach (KeyValuePair<string, string> kv in data)
                {
                    if (oldText.Contains(kv.Key))
                    {
                        para.ReplaceText(kv.Key, kv.Value);
                    }
                }
            }
        }

        public static void UpImage(XWPFDocument doc, FileStream fs, string placeholder, int width, int height)
        {
            if (doc == null || fs == null || fs.Length < 1)
            {
                return;
            }
            foreach (XWPFTable table in doc.Tables)//遍历所有表格数据
            {
                foreach (XWPFTableRow row in table.Rows)
                {
                    foreach (XWPFTableCell cell in row.GetTableICells())
                    {
                        foreach (var para in cell.Paragraphs)
                        {
                            if (para.ParagraphText.Contains(placeholder))
                            {
                                para.Runs[0].AddPicture(fs, 5, "imageName", width, height);
                                para.ReplaceText(placeholder, "");
                            }
                        }
                    }
                }
            }

            foreach (var para in doc.Paragraphs)//遍历所有表格以外的数据
            {
                if (para.ParagraphText.Contains(placeholder))
                {
                    para.Runs[0].AddPicture(fs, 5, "imageName", width, height);
                    para.ReplaceText(placeholder, "");
                }
            }
            fs.Dispose();
        }
    }
}
