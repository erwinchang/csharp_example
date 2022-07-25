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

            List<Employee> empList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Tim",Age=30},
                new Employee(){Id=2,Name="Tom",Age=26},
                new Employee(){Id=3,Name="Guo",Age=26},
                new Employee(){Id=4,Name="Yan",Age=25},
                new Employee(){Id=5,Name="Owen",Age=30}
            };
            this.listBoxEmplyee.DisplayMemberPath = "Name";
            this.listBoxEmplyee.SelectedValuePath = "Id";
            this.listBoxEmplyee.ItemsSource = empList;
        }
    }
}
