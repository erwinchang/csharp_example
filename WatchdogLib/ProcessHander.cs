using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib
{
    public class ProcessHander
    {
        private Stopwatch _nonresponsiveInterval;
        private Stopwatch _fromStart;
        public bool WaitForExit { get; set; }
        public bool RunInDir { get; set; }
        public uint NonresponsiveInterval { get; set; }
        public uint StartingInterval { get; set; }

        public void ProcessHandler()
        {
            WaitForExit = true;
            RunInDir = true;
            NonresponsiveInterval = 2000;
            StartingInterval = 5000;
            _nonresponsiveInterval = new Stopwatch();
            _fromStart = new Stopwatch();
        }
    }
}
