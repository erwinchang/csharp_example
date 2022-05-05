# csharp_example

### Thread

[Thread 類別][1]
可建立和控制執行緒，設定執行緒的優先權，並取得它的狀態。
Join: 會等待thread結束才會往下執行

```
Main thread: Start a second thread.
Main thread: Do some work.
Main thread: Do some work.
Main thread: Do some work.
Main thread: Do some work.
Main thread: Call Join(), to wait until ThreadProc ends.
ThreadProc: 0
ThreadProc: 1
ThreadProc: 2
ThreadProc: 3
ThreadProc: 4
ThreadProc: 5
ThreadProc: 6
ThreadProc: 7
ThreadProc: 8
```

[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.threading.thread?view=net-6.0