# csharp_example

## TCP Example

Server端使用Thread來接 client資料  
1   Server: new Thread(ListenClientConnect)    
1.2 Server/ListenClientConnect: 等待Accept()，當有Client連入，產生新的Thread(ReceiveMessage)  

<a href="https://imgur.com/wzJldYD"><img src="https://i.imgur.com/wzJldYD.png" title="source: imgur.com" width="400px" /></a>

<a href="https://imgur.com/L0Jhuir"><img src="https://i.imgur.com/L0Jhuir.png" title="source: imgur.com" width="400px"/></a>