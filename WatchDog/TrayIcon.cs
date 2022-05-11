using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            private ContextMenuStrip _trayIconContextMenu;
            private ToolStripMenuItem _showLogMenuItem;
            private ToolStripMenuItem _closeMenuItem;
            private Logger _logger;
            private MainForm _mainForm;

            public TrayIcon()
            {
                Application.ApplicationExit += OnApplicationExit;
                InitializeComponent();

                // Todo visibility dependent on configuration. If not, only show config form on 2nd startup

                _logForm = new LogForm() { Visible = false };
                _mainForm = new MainForm();
                _trayIcon.Visible =true;

                InitializeApplication();
            }
            private void OnApplicationExit(object sender, EventArgs e)
            {
                _logger.Info("Stopping the watchdog application");
                if (_trayIcon != null) _trayIcon.Visible = false;
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

                    _logger.Trace("InitializeComponent init");

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

                    // Optional - Add a context menu to the TrayIcon:
                    _trayIconContextMenu = new ContextMenuStrip();

                    _trayIconContextMenu.SuspendLayout();
                    _trayIconContextMenu.Name = "_trayIconContextMenu";
                    _trayIconContextMenu.Size = new Size(153, 70);

                    // Show log
                    _showLogMenuItem = new ToolStripMenuItem
                    {
                        Name = "_showLogMenuItem",
                        Size = new Size(152, 22),
                        Text = "Show watchdog log"
                    };
                    _showLogMenuItem.Click += ShowLogMenuItemClick;
                    _trayIconContextMenu.Items.AddRange(new ToolStripItem[] { _showLogMenuItem });

                    // CloseMenuItem
                    _closeMenuItem = new ToolStripMenuItem
                    {
                        Name = "_suspendResumeMenuItem",
                        Size = new Size(152, 22),
                        Text = "Suspend watchdog server"
                    };
                    _closeMenuItem.Click += CloseMenuItemClick;
                    _trayIconContextMenu.Items.AddRange(new ToolStripItem[] { _closeMenuItem });

                    _trayIconContextMenu.ResumeLayout(false);
                    _trayIcon.ContextMenuStrip = _trayIconContextMenu;
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

            private void ShowLogMenuItemClick(object sender, EventArgs e)
            {
                _logForm.Visible = true;
            }

            private void CloseMenuItemClick(object sender, EventArgs e)
            {
                ApplicationExit();
            }

            private void ApplicationExit()
            {
                _trayIcon.Visible = false;
                OnApplicationExit(this, null);
            }

            private void InitializeApplication()
            {
                try
                {
                    _logger = LogManager.GetLogger("WatchdogServer");
                    var nlogEventTarget = Utilities.NlogEventTarget.Instance;
                    nlogEventTarget.OnLogEvent += OnLogEvent;

                    _logger.Trace("InitializeApplication init");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ex:{ex.Message}");
                }
            }
            private void OnLogEvent(object sender, Utilities.LogEventArgs logEventArgs)
            {
                foreach (var logLine in logEventArgs.LogLines)
                {
                    Debug.WriteLine(logLine);
                }
            }
        }
    }
}
