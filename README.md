# csharp_example

## TCP Server/Client Example

1.採用TcpClient方式
Server: 採用Thread / ListenClientConnect來接Client連線
當Client連進來，每個Client在建立RX Thread/ReceiveMessage，一直loop讀資料

server
```
IPAddress _localAddress = IPAddress.Parse("127.0.0.1");
IPEndPoint ipe = new IPEndPoint(_localAddress, _port);
TcpListener tcpListener = new TcpListener(ipe); 
tcpListener.Start();

TcpClient tcpClient = tcpListener.AcceptTcpClient();  //此時會等待Client連線才會往下執行
```

client
```
TcpClient tcpClient = new TcpClient();
IPHostEntry remoteHost = Dns.GetHostEntry("127.0.0.1");
tcpClient.Connect(remoteHost.HostName, _port);  //等待 跟server連線

Thread receiveThread = new Thread(ReceiveMessage);
receiveThread.IsBackground = true;  //設定背景，當form close時才會強制關閉
receiveThread.Start(_tcpClient);
```

<a href="https://imgur.com/FMmmBeA"><img src="https://i.imgur.com/FMmmBeA.png" title="source: imgur.com" width="500px" /></a>

------

2.注意
2.1 [detecting tcp disconnect][1]

- TcpClient / NetworkStream does not get notified when the connection is closed.  
- The only option available to you is to catch exceptions when writing to the stream. 
因此當Client斷線時，無去得知，因為CanRead及Connnect都還是true
需加入判斷如下

```
if (mytcpClient.Client.Poll(1, SelectMode.SelectRead) && !networkStream.DataAvailable)
{
	mytcpClient.GetStream().Close();
	mytcpClient.Close();
}                       
```

2.2 在元件InvokeRequired遇到FormClose需要加入下例判斷

ctlobj.IsDisposed
[Close a form from an external thread using the Invoke method][2]

```
        public void PrintTextToRichTextBox(string strText, RichTextBox ctlobj)
        {
            string arg = string.Empty;
            try
            {
                if (ctlobj.IsDisposed)
                {
                    return;
                }
                if (ctlobj.InvokeRequired)
                {
```

[1]:https://stackoverflow.com/questions/15067014/c-sharp-detecting-tcp-disconnect
[2]:https://stackoverflow.com/questions/10084691/close-a-form-from-an-external-thread-using-the-invoke-method