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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //BindingData.vm.Header = "Header111";
            gridMain.DataContext = this;
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {

        }

        public String Header1
        {
            get
            {
                return "Header 1";
            }
        }

        public String Header2
        {
            get
            {
                return "Header 2";
            }
        }

        public String ContentText
        {
            get
            {
                return "Hello World, this is my first control!";
            }
        }
    }
}
