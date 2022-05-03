# csharp_example
## [Application.Restart][1]


執行輸出如下(D:\log1.txt)  
```
Main| Load| LoadFinish| Closing|  => 正常操作，按下Y
Main| Load| LoadFinish| Main| Load| LoadFinish| Main| Load|  => 按下N，會重啟程式(LoadFinish| Main| Load)，目前的function會跑完再重啟
```


[1]:https://www.delftstack.com/zh-tw/howto/csharp/restart-application-csharp/