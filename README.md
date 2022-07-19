# csharp_example

## net example 01


```
string strHostName = Dns.GetHostName();
IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

foreach (IPAddress ipaddress in iphostentry.AddressList)
{
    Console.WriteLine("IP: " + ipaddress.ToString() + ", AddressFamily : " + ipaddress.AddressFamily.ToString());
}
```

```
IP: fe80::--:2f62:25d3%17, AddressFamily : InterNetworkV6
IP: fe80::--:6289:90f6%33, AddressFamily : InterNetworkV6
IP: fe80::--:abf7:af0e%95, AddressFamily : InterNetworkV6
IP: fe80::--:a8c1:600a%52, AddressFamily : InterNetworkV6
IP: 192.168.200.50, AddressFamily : InterNetwork
IP: 172.18.76.131, AddressFamily : InterNetwork
IP: 172.28.192.1, AddressFamily : InterNetwork
IP: 172.22.128.1, AddressFamily : InterNetwork
IPEndPoint: 127.0.0.1:80
IP Port: 80
IP AddressFamily: InterNetwork
IPEndPoint MaxPort: 65535
IPEndPoint MinPort: 0
```

<a href="https://imgur.com/0IKK4PJ"><img src="https://i.imgur.com/0IKK4PJ.png" title="source: imgur.com" width="400px"/></a>