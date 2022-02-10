using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        private static NLog.Logger Logger = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger = NLog.LogManager.GetCurrentClassLogger();
            Logger.Fatal("Hello {0}", "Fatal");
            Logger.Error("Hello {0}", "Error");
            Logger.Warn("Hello {0}", "Warn");
            Logger.Info("Hello {0}", "Info");
            Logger.Debug("Hello {0}", "Debug");
            Logger.Trace("Hello {0}", "Trace");
        }
    }
}
