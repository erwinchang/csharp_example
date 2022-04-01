using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    class MyProgram
    {
    }
    public class Example
    {
        public void Main()
        {
            Console.WriteLine("test main");
        }
    }
    interface iTarget
    {
        void Request();
        String fileName { get; set; }
    }
    class Adaptee
    {
        public string fileName;
        public void SpecificRequest()
        {
            if(fileName.IndexOf(".csv") != -1)
            {
                MessageBox.Show("open csv file to process.", "Sucessfully");
            }
            else
            {
                MessageBox.Show("Unable to process this file [file format error].", "Failure");
            }
        }
    }
    class Adapter : Adaptee,iTarget
    {
        public void Request()
        {
            base.fileName = ConverToCSV(this.fileName);
            this.SpecificRequest();
        }
        public new String fileName
        {
            get;
            set;
        }
        public string ConverToCSV(string fileName)
        {
            //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/base
            //base 關鍵字是用來存取衍生類別中基底類別的成員
            //https://www.itread01.com/content/1544002264.html
            //this關鍵字代表本類物件，base關鍵字代表父類物件
            //base是為了實現子類的方法中實現父類原有的方法
            base.fileName = fileName.Replace(".xml",".csv").Replace(".xls",".csv").Replace(".txt",".csv");         
            string msg = "All file transform to CSV file.\nProcess Result:";
            msg = msg + fileName + "to" + base.fileName;
            MessageBox.Show(msg,"轉換器處理");
            return base.fileName;
        }
    }
}
