using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchDog.Properties;

namespace WatchDog
{
    namespace TrayIconTest
    {
        class TrayIcon : ApplicationContext
        {
            //Component declarations
            private NotifyIcon _trayIcon;
            private LogForm _logForm;
            private Logger _logger;
            private MainForm _mainForm;

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
                    var path = Path.GetDirectoryName(Application.ExecutablePath);
                    if (!String.IsNullOrEmpty(path) && Directory.Exists(path))
                        Directory.SetCurrentDirectory(path);

                    _logger = LogManager.GetLogger("WatchdogServer");
                    ExceptionsManager.Logger = _logger;

                    _logger.Trace("test");

                    _trayIcon = new NotifyIcon();
                    ExceptionsManager.TrayIcon = _trayIcon;
                    _trayIcon.Text = "Watchdog";
                    _trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                    _trayIcon.BalloonTipText = "Starting watchdog";
                    _trayIcon.BalloonTipTitle = "Starting watchdog";
                    _trayIcon.Text = "Watchdog";

                    //The icon is added to the project resources.
                    _trayIcon.Icon = Resources.watchdog;

                    //Optional - handle double-clicks on the icon:
                    _trayIcon.Click += TrayIconClick;
                    _trayIcon.DoubleClick += TrayIconDoubleClick;

                }
                catch (Exception ex)
                {
                    ExceptionsManager.ServerCrash("Exception Watchdog initialization", "Exception during Watchdog initialization :" + ex.Message, true);
                }
            }

            private void TrayIconClick(object sender, EventArgs e)
            {
                var me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Console.WriteLine(".MouseButtons.Left");
                    //_logForm.Visible = true;
                    _mainForm.Visible = true;
                }
            }

            private void TrayIconDoubleClick(object sender, EventArgs e)
            {
                _logForm.Visible = true;
            }
        }
    }
}
