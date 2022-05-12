using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib
{
    public class HeartbeatServer
    {
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
        }
    }
}
