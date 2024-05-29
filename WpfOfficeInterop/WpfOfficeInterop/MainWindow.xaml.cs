using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfOfficeInterop
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private cpMessageBox m_MessageBox = new cpMessageBox();
        public MainWindow()
        {
            InitializeComponent();
            string txtMsg = string.Empty;
            try
            {
                //if (!WordTemplate1.Test(ref txtMsg))
                //    throw new Exception(txtMsg);

                if (!WordTemplate2.Test(ref txtMsg))
                    throw new Exception(txtMsg);

                //if (!WordTemplate3.Test(ref txtMsg))
                //    throw new Exception(txtMsg);
            }
            catch (Exception ex)
            {
                int num1 = (int)m_MessageBox.Show(txtMsg, "Error", "OK", "Error", options: "None");
            }
        }
    }
}
