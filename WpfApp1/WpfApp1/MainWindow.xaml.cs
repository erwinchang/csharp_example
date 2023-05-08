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
        private ListViewDragDropMg<ListTestPlan> dragMgr;

        public MainWindow()
        {
            InitializeComponent();
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class1", Standard = "Standard1" });
            Global.listPlan.Add(new ListTestPlan { Switch = false, Class = "Class2", Standard = "Standard2" });
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class3", Standard = "Standard3" });

            listViewTestPlan.ItemsSource = Global.listPlan;

            Global.listPlan2.Add(new ListTestPlan { Switch = true, Class = "Class4", Standard = "Standard4" });
            listViewTestPlan2.ItemsSource = Global.listPlan2;

            dragMgr = new ListViewDragDropMg<ListTestPlan>(listViewTestPlan);
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

        //https://www.codeproject.com/Articles/1236549/Csharp-WPF-listview-Drag-Drop-a-Custom-Item
        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            ListTestPlan item = null;
            int index = -1;

            if (listViewTestPlan.SelectedItems.Count != 1) return;
            item = (ListTestPlan)listViewTestPlan.SelectedItems[0];
            index = Global.listPlan.IndexOf(item);
            if (index > 0)
            {
                Global.listPlan.Move(index, index - 1);
            }
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            ListTestPlan item = null;
            int index = -1;

            if (listViewTestPlan.SelectedItems.Count != 1) return;
            item = (ListTestPlan)listViewTestPlan.SelectedItems[0];
            index = Global.listPlan.IndexOf(item);
            if (index < Global.listPlan.Count - 1)
            {
                Global.listPlan.Move(index, index + 1);
            }
        }
    }
}
