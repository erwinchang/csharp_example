using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public class ListViewDragDropMg<ItemType> where ItemType : class
    {
        private ListView listView;

        public ListViewDragDropMg()
        {
            int i = 0;
        }

        public ListViewDragDropMg(ListView listView)
          : this()
        {
            ListView = listView;
        }

        public ListView ListView
        {
            get => this.listView;
            set
            {
                //if (this.IsDragInProgress)
                //    throw new InvalidOperationException("Cannot set the ListView property during a drag operation.");
                //if (this.listView != null)
                //{
                //    this.listView.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(this.listView_PreviewMouseLeftButtonDown);
                //    this.listView.PreviewMouseMove -= new MouseEventHandler(this.listView_PreviewMouseMove);
                //    this.listView.DragOver -= new DragEventHandler(this.listView_DragOver);
                //    this.listView.DragLeave -= new DragEventHandler(this.listView_DragLeave);
                //    this.listView.DragEnter -= new DragEventHandler(this.listView_DragEnter);
                //    this.listView.Drop -= new DragEventHandler(this.listView_Drop);
                //}
                this.listView = value;
                if (this.listView == null)
                    return;
                if (!this.listView.AllowDrop)
                    this.listView.AllowDrop = true;
                //this.listView.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(this.listView_PreviewMouseLeftButtonDown);
                //this.listView.PreviewMouseMove += new MouseEventHandler(this.listView_PreviewMouseMove);
                //this.listView.DragOver += new DragEventHandler(this.listView_DragOver);
                //this.listView.DragLeave += new DragEventHandler(this.listView_DragLeave);
                //this.listView.DragEnter += new DragEventHandler(this.listView_DragEnter);
                //this.listView.Drop += new DragEventHandler(this.listView_Drop);
            }
        }

        private void listView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WriteLine("listView_PreviewMouseLeftButtonDown");
        }
        private void listView_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            WriteLine("listView_PreviewMouseMove");
        }
        private void listView_DragOver(object sender, DragEventArgs e)
        {
            WriteLine("listView_DragOver");
        }
        private void listView_DragLeave(object sender, DragEventArgs e)
        {
            WriteLine("listView_DragLeave");
        }
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            WriteLine("listView_DragEnter");
        }
        private void listView_Drop(object sender, DragEventArgs e)
        {
            WriteLine("listView_Drop");
        }
        private void WriteLine(string Msg)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"), Msg);
        }
    }
}
