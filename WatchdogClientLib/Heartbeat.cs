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
        private Stopwatch _stopwatchHeartBeat;
        public uint Timeout { get; private set; }

        public Heartbeat()
        {
            _processName = Process.GetCurrentProcess().ProcessName;
            Initialize();
        }

        private void Initialize()
        {
            Timeout = 5;
            _client.ServerMessage += OnServerMessage;
            _client.Disconnected += OnDisconnected;
            _client.Connected += OnConnected;
            _client.AutoReconnect = true;
            _client.Start();
            _stopwatchHeartBeat = new Stopwatch();
            _stopwatchHeartBeat.Start();
        }
        private void OnServerMessage(NamedPipeConnection<string, string> connection, string message)
        {

        }

        private void OnDisconnected(NamedPipeConnection<string, string> connection)
        {
        }
        private void OnConnected(NamedPipeConnection<string, string> connection)
        {
            SendCommand(Commands.Heartbeat, _processName);
        }

        private enum Commands
        {
            SetTimeOut,
            Heartbeat,
            RequestKill,
        }

        private void SendCommand<T>(Commands command, T argument)
        {
            _client.PushMessage(((int)command).ToString() + "," + argument.ToString());
        }
    }
}
