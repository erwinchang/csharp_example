# csharp_example

## Thread /IsBackground差別  

[背景執行緒與前景執行緒的差別][1]  

Thread.IsBackground=false  
此時為背景，好處若主程式離開，此時背景程式會馬上自動關閉離開  
因此主程式可以加入Join來確保Thread有正常執行完成  

<a href="https://imgur.com/v2zoe2J"><img src="https://i.imgur.com/v2zoe2J.png" title="source: imgur.com" width="400px" /></a>


Thread.IsBackground=true  
此時為前景，好處若主程式離開，此時會等Thread執行完才會離開    

<a href="https://imgur.com/TU1qf1O"><img src="https://i.imgur.com/TU1qf1O.png" title="source: imgur.com" width="400px" /></a>

[1]:https://dotblogs.com.tw/yc421206/2011/01/04/20574