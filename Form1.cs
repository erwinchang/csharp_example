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

            //https://ithelp.ithome.com.tw/articles/10074475
            Closing += new CancelEventHandler(Form1_Closing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.File.AppendAllText("D:\\log1.txt", "Load| ");

            //https://www.delftstack.com/zh-tw/howto/csharp/restart-application-csharp/
            DialogResult dr = MessageBox.Show("Are you happy now?", "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Ok, Bye");
                    break;
                case DialogResult.No:
                    Application.Restart();
                    break;
            }

            System.IO.File.AppendAllText("D:\\log1.txt", "LoadFinish| ");
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.IO.File.AppendAllText("D:\\log1.txt", "Closing| ");
        }
    }
}
