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
        public static string WindowTitel = "Title Test11";
        public static string ShowText { get { return "Show Test22"; } }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void buttonVictor_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DependencyObject leve1 = VisualTreeHelper.GetParent(btn);
            DependencyObject leve2 = VisualTreeHelper.GetParent(leve1);
            DependencyObject leve3 = VisualTreeHelper.GetParent(leve2);
            MessageBox.Show(leve3.GetType().ToString());
        }
    }
}
