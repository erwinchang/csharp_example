using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib
{
    public class HeartbeatClient
    {
        public HeartbeatClient(string name)
        {
            Name = name;
            RequestKill = false;
            LastHeartbeat = DateTime.Now;
            LogManager.GetLogger("WatchdogServer");

        }
        public string Name { get; set; }
        public string ProcessName { get; set; }
        public DateTime LastHeartbeat { get; set; }
        public bool RequestKill { get; set; }
        public DateTime KillTime { get; set; }
    }
    public class HeartbeatServer
    {
        private enum Commands
        {
            SetTimeOut,
            Heartbeat,
            RequestKill,
        }

        private const string PipeName = "named_pipe_watchdog";
        private readonly NamedPipeServer<string> _server = new NamedPipeServer<string>(PipeName);
        private readonly ISet<HeartbeatClient> _clients = new HashSet<HeartbeatClient>();
        private readonly DateTime _serverStarted;

        private static HeartbeatServer _instance;
        public static HeartbeatServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HeartbeatServer();
                }
                return _instance;
            }
        }

        public Logger Logger { get; set; }

        private HeartbeatServer()
        {
            Logger = LogManager.GetLogger("WatchdogServer");
            _server.ClientConnected += OnClientConnected;
            _server.ClientDisconnected += OnClientDisconnected;
            _server.ClientMessage += OnClientMessage;
            _serverStarted = DateTime.Now;
            _server.Start();
        }

        private void OnClientMessage(NamedPipeConnection<string, string> connection, string message)
        {
            var args = message.Split(',');
            if (args.Length == 0) return;
            uint command; if (!uint.TryParse(args[0], out command)) return;

            switch (command)
            {
                case (int)Commands.Heartbeat:
                    {
                        Debug.WriteLine("received Commands.Heartbeat");
                        var client = FindByName(connection.Name);
                        if (client == null) break;
                        if (args.Length < 2) return;
                        client.ProcessName = args[1];
                        client.LastHeartbeat = DateTime.Now;
                        Debug.WriteLine("received heartbeat");
                    }
                    break;
                case (int)Commands.RequestKill:
                    {
                        Debug.WriteLine("received Commands.RequestKill");
                    }
                    break;
                default:
                    Debug.WriteLine("Unrecognized command");
                    break;
            }

        }

        private void OnClientConnected(NamedPipeConnection<string, string> connection)
        {
            if (FindByName(connection.Name) == null)
            {
                _clients.Add(new HeartbeatClient(connection.Name));
            }
            //SendCommand(Commands.SetTimeOut, HardTimeout);
        }

        private void OnClientDisconnected(NamedPipeConnection<string, string> connection)
        {
            var client = FindByName(connection.Name);
            if (client != null) _clients.Remove(client);
        }

        public HeartbeatClient FindByName(string name)
        {
            //https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.hashset-1?view=net-6.0
            //傳回序列中符合條件的第一個元素；如果找不到這類元素，則傳回預設值
            return _clients.FirstOrDefault((client) => client.Name == name);
        }
    }
}
