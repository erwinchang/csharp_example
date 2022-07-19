using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class MyServer
    {
        private static byte[] result = new byte[1024];
        private static int myport = 8012;
        static Socket serverSocket;
        public void Test()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myport));
            serverSocket.Listen(10);
            Console.WriteLine("Servier Listen {0}", serverSocket.LocalEndPoint.ToString());

            string sendMessage = "server send Message Hello";
            Socket clientSocket = serverSocket.Accept();
            clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
            Console.WriteLine("Send Client Message:{0}", sendMessage);

            int receiveNumber = clientSocket.Receive(result);
            Console.WriteLine("receive {0}: {1}", clientSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(result));
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            Console.ReadLine();
        }
    }
}
