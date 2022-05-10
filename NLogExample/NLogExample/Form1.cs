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

namespace NLogExample
{
    public partial class Form1 : Form
    {
        private Logger _logger;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Logger log = LogManager.GetCurrentClassLogger();
            //Logger log = LogManager.GetLogger("WatchdogServer");
            //log.Debug("test debug");
            //Console.WriteLine("test11");
            try
            {
                _logger = LogManager.GetLogger("WatchdogServer");
                _logger.Debug("test debug111");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ex:{ex.Message}");
            }
        }
    }
}
