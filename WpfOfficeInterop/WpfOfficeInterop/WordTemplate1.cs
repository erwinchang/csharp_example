using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace WpfOfficeInterop
{
    public class WordTemplate1
    {
        //https://www.cc.ntu.edu.tw/chinese/epaper/home/News_Content_n_103858_s_220288.html
        public static bool Test(ref string strRet)
        {
            bool flag = true;

            Application appWord = null;
            Document doc = null;
            var template = "D:\\template1.docx";
            var templateTxt = "D:\\template1.txt";
            var templateOut = "D:\\template1Out.docx";
            try
            {
                if (File.Exists(templateOut))
                    File.Delete(templateOut);

                appWord = new Application();
                appWord.Visible = true;
                appWord.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                doc = appWord.Documents.Open(template,ReadOnly:false);
                doc.MailMerge.OpenDataSource(templateTxt);
                doc.MailMerge.Destination = WdMailMergeDestination.wdSendToNewDocument;
                doc.MailMerge.Execute(false);
                appWord.Documents[1].SaveAs2(templateOut, WdSaveFormat.wdFormatDocumentDefault);
                appWord.Documents[1].Close();
                doc.MailMerge.DataSource.Close();
            }
            catch(Exception ex)
            {
                flag = false;
                strRet = string.Format("[Test] {0}", ex.Message);
            }
            finally
            {
                if(doc != null)
                {
                    doc.Close(WdSaveOptions.wdDoNotSaveChanges);
                }
                if(appWord != null)
                {
                    appWord.Quit();
                }
                doc = null;
                appWord = null;
            }
            return flag;
        }
    }
}
