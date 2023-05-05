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
        }

        //https://blog.csdn.net/qq_43024228/article/details/110454081
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {

            var layer = AdornerLayer.GetAdornerLayer(myButton);
            layer.Add(new TestAdorner(myButton));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var layer = AdornerLayer.GetAdornerLayer(myButton);
            var arr = layer.GetAdorners(myButton);
            if(arr != null)
            {
                for(int i= arr.Length-1; i >= 0; i--)
                {
                    layer.Remove(arr[i]);
                }
            }
        }
    }
}
