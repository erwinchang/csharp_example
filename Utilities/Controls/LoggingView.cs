using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

    }
}
