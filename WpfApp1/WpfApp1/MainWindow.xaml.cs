using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private Point startPoint = new Point();
        private int startIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class1", Standard = "Standard1" });
            Global.listPlan.Add(new ListTestPlan { Switch = false, Class = "Class2", Standard = "Standard2" });
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class3", Standard = "Standard3" });
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class4", Standard = "Standard4" });
            Global.listPlan.Add(new ListTestPlan { Switch = false, Class = "Class5", Standard = "Standard5" });
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class6", Standard = "Standard6" });
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class7", Standard = "Standard7" });
            Global.listPlan.Add(new ListTestPlan { Switch = false, Class = "Class8", Standard = "Standard8" });
            Global.listPlan.Add(new ListTestPlan { Switch = true, Class = "Class9", Standard = "Standard9" });

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

        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        private void listViewTestPlan_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get current mouse position
            startPoint = e.GetPosition(null);
            string txtMsg = string.Format("[PreviewMouseLeftButtonDown] {0}", startPoint.ToString());
            WriteLine(txtMsg);

            bool canInitiateDrag = false; ;
            if (IsMouseOverScrollbar() == false)
            {
                int indexUnderDragCursor = IndexUnderDragCursor();
                canInitiateDrag = indexUnderDragCursor > -1;
            }

        }
        private bool IsMouseOverScrollbar()
        {
            Point p1 = MouseUti.GetMousePosition((Visual)listViewTestPlan);
            HitTestResult hitTestResult = VisualTreeHelper.HitTest((Visual)listViewTestPlan, p1);
            ScrollBar ScrollBar1 = FindAnchestor<ScrollBar>((DependencyObject)hitTestResult.VisualHit);
            if (ScrollBar1 == null) return false;           // Abort
            return true;
        }
        private int IndexUnderDragCursor()
        {
            int indexUnderDragCursor = -1;
            for (int index = 0; index < this.listViewTestPlan.Items.Count; ++index)
            {
                if (this.MyIsMouseOver((Visual)this.GetListViewItem(index)))
                {
                    indexUnderDragCursor = index;
                    WriteLine(string.Format("[IndexUnderDragCursor] indexUnderDragCursor:{0}", indexUnderDragCursor));
                    break;
                }
            }
            return indexUnderDragCursor;
        }
        private ListViewItem GetListViewItem(int index)
        {
            if(listViewTestPlan.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
            {
                return (ListViewItem)null;
            }
            else
            {
                ListViewItem l1= listViewTestPlan.ItemContainerGenerator.ContainerFromIndex(index) as ListViewItem;
                return l1;
            }
        }
        private bool MyIsMouseOver(Visual target)
        {
            if(target != null)
            {
                if (VisualTreeHelper.GetDescendantBounds(target).Contains(MouseUti.GetMousePosition(target)))
                {
                    return true;
                }
            }
            return false;
        }
        private void WriteLine(string Msg)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"), Msg);
        }

        private void listViewTestPlan_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
             WriteLine(string.Format("[MouseMove] mousePos:{0}, minH:{1}, minV:{2}, diff:{3}", mousePos.ToString(), SystemParameters.MinimumHorizontalDragDistance, SystemParameters.MinimumVerticalDragDistance, diff.ToString()));

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                       Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);
                if (listViewItem == null) return;           // Abort
                                                            // Find the data behind the ListViewItem
                ListTestPlan item = (ListTestPlan)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                if (item == null) return;                   // Abort
                                                            // Initialize the drag & drop operation
                startIndex = listViewTestPlan.SelectedIndex;
                DataObject dragData = new DataObject("ListTestPlan", item);
               //DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy | DragDropEffects.Move);

                if (DragDrop.DoDragDrop((DependencyObject)listViewItem, (object)dragData, DragDropEffects.Copy | DragDropEffects.Move) == DragDropEffects.None)
                    return;
                WriteLine("[MouseMove] DoDragDrop Finish");
            }
        }

        private void listViewTestPlan_DragEnter(object sender, DragEventArgs e)
        {
            WriteLine("[DragEnter]");
            if (!e.Data.GetDataPresent("ListTestPlan") || sender != e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void listViewTestPlan_Drop(object sender, DragEventArgs e)
        {
            WriteLine("[Drop]");
            int index = -1;

            if (e.Data.GetDataPresent("ListTestPlan") && sender == e.Source)
            {
                // Get the drop ListViewItem destination
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);
                if (listViewItem == null)
                {
                    // Abort
                    e.Effects = DragDropEffects.None;
                    return;
                }
                // Find the data behind the ListViewItem
                ListTestPlan item = (ListTestPlan)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                // Move item into observable collection 
                // (this will be automatically reflected to lstView.ItemsSource)
                e.Effects = DragDropEffects.Move;
                index = Global.listPlan.IndexOf(item);
                if (startIndex >= 0 && index >= 0)
                {
                    Global.listPlan.Move(startIndex, index);
                }
                startIndex = -1;        // Done!
            }
        }
    }
}
