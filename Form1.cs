using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnXMLFile_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/how-to-open-files-using-the-openfiledialog-component?view=netframeworkdesktop-4.8
            OpenFileDialog  openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();            
            TxtXMLFile.Text= openFileDialog1.FileName;
            Console.WriteLine($"file:{openFileDialog1.FileName}");
        }
    }
}
