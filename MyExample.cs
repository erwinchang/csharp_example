using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    public class MyExample
    {
        public void Test()
        {
            Console.WriteLine("Test");
            //IPAddress[] addr = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            //https://dotblogs.com.tw/mingstyle/2013/03/09/96041
            string strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                Console.WriteLine("IP: " + ipaddress.ToString() + ", AddressFamily : " + ipaddress.AddressFamily.ToString());
            }

            IPAddress localIp = IPAddress.Parse("127.0.0.1");
            IPEndPoint iep = new IPEndPoint(localIp, 80);
            Console.WriteLine("IPEndPoint: " + iep.ToString());
            Console.WriteLine("IP Port: " + iep.Port.ToString());
            Console.WriteLine("IP AddressFamily: " + iep.AddressFamily.ToString());
            Console.WriteLine("IPEndPoint MaxPort: " + IPEndPoint.MaxPort);
            Console.WriteLine("IPEndPoint MinPort: " + IPEndPoint.MinPort);
        }
    }
}
