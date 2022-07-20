using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class MyExample
    {
        private static int remoteReceivePort = 8012;
        public void Test()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sendSocket.SendTo(Encoding.UTF8.GetBytes("Test Data"), new IPEndPoint(ip, remoteReceivePort));
            Console.WriteLine("send test data");
            sendSocket.Shutdown(SocketShutdown.Send);
            sendSocket.Close();
            Console.ReadLine();
        }
    }
}
