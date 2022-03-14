using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnTXT_Click(object sender, EventArgs e)
        {
            var Processor = FileProcessorFactory.getInstance("TXT");
            string result = Processor.Open();
            Console.WriteLine($"result: {result}, BtnTXT_Click");
        }

        private void BtnXML_Click(object sender, EventArgs e)
        {
            var Processor = FileProcessorFactory.getInstance("XML");
            string result = Processor.Open();
            Console.WriteLine($"result: {result}, BtnXML_Click");
        }

        private void BtnXLS_Click(object sender, EventArgs e)
        {
            var Processor = FileProcessorFactory.getInstance("XLS");
            string result = Processor.Open();
            Console.WriteLine($"result: {result}, BtnXLS_Click");
        }
    }
}
