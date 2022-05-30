using System;
using System.Diagnostics;


namespace WatchdogClient
{
    public class Heartbeat
    {
        private const string PipeName = "named_pipe_watchdog";
        private readonly NamedPipeClient<string> _client = new NamedPipeClient<string>(PipeName);
        private readonly string _processName;
        private Stopwatch _stopwatchHeartBeat;
        public uint Timeout { get; private set; }
        public bool Terminate { get; private set; }

        public Heartbeat()
        {
            _processName = Process.GetCurrentProcess().ProcessName;
            Initialize();
        }

        private void Initialize()
        {
            Terminate = false;
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
            var args = message.Split(',');
            Debug.WriteLine($"Clinet OnServerMessage,message:{message},args len:{args.Length}");
            if (args.Length == 0) return;
            uint command; if (!uint.TryParse(args[0], out command)) return;

            switch (command)
            {
                case (int)Commands.SetTerminate:
                    {
                        Terminate = true;
                    }                   
                    break;
                default:
                    Debug.WriteLine("Unrecognized command");
                    break;
            }
        }

        public void SendHeartbeat()
        {
            if (_stopwatchHeartBeat.ElapsedMilliseconds > 25)
            {
                _stopwatchHeartBeat.Restart();
                SendCommand(Commands.Heartbeat, _processName);
            }
        }
        public void RequestKill()
        {
            SendCommand(Commands.RequestKill, _processName);
        }

        public void RequestKill(uint sec)
        {
            SendCommand(Commands.RequestKill, _processName, sec);
        }

        public void RequestInactive()
        {
            SendCommand(Commands.RequestInactive, _processName);
        }

        private void OnDisconnected(NamedPipeConnection<string, string> connection)
        {
            Debug.WriteLine("Heartbeat, OnDisconnected");
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
            RequestInactive,
            SetTerminate
        }

        private void SendCommand<T>(Commands command, T argument)
        {
            _client.PushMessage(((int)command).ToString() + "," + argument.ToString());
        }
        private void SendCommand<T1, T2>(Commands command, T1 argument1, T2 argument2)
        {
            _client.PushMessage(((int)command).ToString() + "," + argument1.ToString() + "," + argument2.ToString());
        }
    }
}
