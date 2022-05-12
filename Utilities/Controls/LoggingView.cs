using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities.Controls
{
    public partial class LoggingView : ListBox
    {
        public LoggingView()
        {
            InitializeComponent();

            //https://blog.csdn.net/weixin_44855978/article/details/103803956
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        public int MaxEntriesInListBox { get; set; }

        public void AddEntry(string[] items)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { AddEntry(items); }));
                return;
            }
            BeginUpdate();
            foreach (var item in items)
            {
                Items.Add(item);
                if (Items.Count > MaxEntriesInListBox)
                {
                    Items.RemoveAt(0);
                }
            }
            EndUpdate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
            }
            base.OnDrawItem(e);
        }
    }
}
