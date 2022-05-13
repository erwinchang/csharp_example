using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogClientLib
{
    public class Heartbeat
    {
        private const string PipeName = "named_pipe_watchdog";
        private readonly NamedPipeClient<string> _client = new NamedPipeClient<string>(PipeName);
        private readonly string _processName;
        public uint Timeout { get; private set; }

        public Heartbeat()
        {
            _processName = Process.GetCurrentProcess().ProcessName;
            Initialize();
        }

        private void Initialize()
        {
            Timeout = 5;
        }
    }
}
