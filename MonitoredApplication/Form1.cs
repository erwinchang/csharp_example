﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            while (true) ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _timer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _heartbeat.RequestKill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _heartbeat.RequestKill(10);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            _heartbeat.RequestInactive();
        }
    }
}
