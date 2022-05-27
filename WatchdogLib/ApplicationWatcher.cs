using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace WatchdogLib
{
    public class ApplicationWatcher
    {
        private readonly Stopwatch _sleepStopwatch;
        private readonly Logger _logger;
        public List<ApplicationHandler> ApplicationHandlers { get; set; }

        public ApplicationWatcher(Logger logger)
        {
            ApplicationHandlers = new List<ApplicationHandler>();
            _sleepStopwatch = new Stopwatch();
            var asyncWorkerMonitor = new AsyncWorker(MonitorJob) { Name = "ApplicationWatcher" };
            asyncWorkerMonitor.Start();
            _logger = logger;
        }

        private bool MonitorJob()
        {
            // Walk through list of applications to see which ones are running
            _sleepStopwatch.Restart();
            foreach (var applicationHandler in ApplicationHandlers.ToArray())
            {
                applicationHandler.Check();
            }
            Thread.Sleep(Math.Max(0, 500 - (int)_sleepStopwatch.ElapsedMilliseconds));
            return true;
        }

        public void Deserialize(Configuration configuration)
        {
            foreach (var applicationHandlerConfig in configuration.ApplicationHandlers)
            {
                var applicationHandler = new ApplicationHandler(applicationHandlerConfig);
                ApplicationHandlers.Add(applicationHandler);
            }
        }
    }
}
