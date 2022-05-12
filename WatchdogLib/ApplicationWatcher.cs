using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib
{
    public class ApplicationWatcher
    {
        private readonly Stopwatch _sleepStopwatch;
        public List<ApplicationHandler> ApplicationHandlers { get; set; }

        public ApplicationWatcher(Logger logger)
        {
            ApplicationHandlers = new List<ApplicationHandler>();
            _sleepStopwatch = new Stopwatch();
        }
    }
}
