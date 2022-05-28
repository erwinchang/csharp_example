using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;
using WatchdogClient;

namespace MonitoredApplication
{
    public partial class MonitoredApplicationForm : Form
    {
        private System.Timers.Timer _timer;
        private Heartbeat _heartbeat;
        private int _heartbeatCount;
        public MonitoredApplicationForm()
        {
            InitializeComponent();
            _heartbeat = new Heartbeat();  // initialize heartbeat

            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += OnTimedEvent;
            _timer.Enabled = true;
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            // Invoke heartbeat on the main thread otherwise it will send even if the main thread is unresponsive
            Invoke(new MethodInvoker(delegate
            {
                _heartbeat.SendHeartbeat();
                //toolStripStatusLabelComments.Text = "Heartbeat " + _heartbeatCount++;
                Debug.WriteLine("Heartbeat " + _heartbeatCount++);
            }));
        }
    }
}
