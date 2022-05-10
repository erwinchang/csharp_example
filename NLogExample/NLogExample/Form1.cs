using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Debug.WriteLine("debug test");
            try
            {
                _logger = LogManager.GetLogger("WatchdogServer");
                
                var nlogEventTarget = NLog.Targets.NlogEventTarget.Instance;
                nlogEventTarget.OnLogEvent += OnLogEvent;

                _logger.Debug($"test debug111 {Environment.NewLine}");
                _logger.Trace($"test debug222 {Environment.NewLine}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ex:{ex.Message}");
            }
        }

        private void OnLogEvent(object sender, NLog.Targets.LogEventArgs logEventArgs)
        {
            foreach (var logLine in logEventArgs.LogLines)
            {
                Debug.WriteLine(logLine);
            }
        }
    }
}
