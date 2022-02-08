using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var log = LogManager.GetCurrentClassLogger();
            log.Fatal("Test: Fatal");
            log.Error("Test: Error");
            log.Warn("Test: Warn");
            log.Info("Test: Info");
            log.Debug("Test: Debug");
            log.Trace("Test: Trace");
            
        }
    }
}
