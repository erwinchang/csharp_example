using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchDog
{
    namespace TrayIconTest
    {
        class TrayIcon : ApplicationContext
        {
            //Component declarations
            private Logger _logger;

            public TrayIcon()
            {
                Application.ApplicationExit += OnApplicationExit;
                InitializeComponent();
            }
            private void OnApplicationExit(object sender, EventArgs e)
            {

            }

            private void InitializeComponent()
            {
                try
                {
                    _logger = LogManager.GetLogger("WatchdogServer");
                    ExceptionsManager.Logger = _logger;

                    _logger.Trace("test");
                }
                catch(Exception ex)
                {
                    ExceptionsManager.ServerCrash("Exception Watchdog initialization", "Exception during Watchdog initialization :" + ex.Message, true);
                }
            }
        }
    }
}
