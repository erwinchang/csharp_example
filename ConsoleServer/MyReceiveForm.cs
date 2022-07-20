using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class MyReceiveForm
    {
        private static int receivePort = 8012;
        public void Test()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket receiveSocket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            receiveSocket.Bind(new IPEndPoint(ip, receivePort));

            byte[] result = new byte[1024];
            EndPoint senderRemote = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            int length = receiveSocket.ReceiveFrom(result, ref senderRemote);
            Console.WriteLine("receive {0} : {1}", senderRemote.ToString(), Encoding.UTF8.GetString(result, 0, length).Trim());
            receiveSocket.Shutdown(SocketShutdown.Receive);
            Console.ReadLine();
        }
    }
}
