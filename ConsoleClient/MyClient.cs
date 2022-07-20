using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class MyClient
    {
        private static byte[] result = new Byte[1024];
        public void Test()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 8012));
                Console.WriteLine("client connect to server success..");
            }
            catch
            {
                Console.WriteLine("client connect to server fail..");
                return;
            }
            int receiveLength = clientSocket.Receive(result);
            Console.WriteLine("client receive message {0}: {1}", clientSocket.RemoteEndPoint.ToString(),Encoding.ASCII.GetString(result,0,receiveLength));

            for(int  i=0; i<5; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                    string sendMessage = "client send Message Hello" + DateTime.Now;
                    clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
                    Console.WriteLine("send to server :{0}", sendMessage);
                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }
            Console.WriteLine("Send Finish..");
            Console.ReadLine();
        }
    }
}
