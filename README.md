# csharp_example


### Delegate

1.Thread無法存取UI問題，如下

<a href="https://imgur.com/gNroYlO"><img src="https://i.imgur.com/gNroYlO.png" title="source: imgur.com" width="400px" /></a>

[Control.InvokeRequired 屬性][2]
取得一個值。這個值會指示是否由於呼叫端是在建立控制項之執行緒以外的執行緒


[多執行緒中InvokeRequired和Invoke的用法，講的很清楚][3]
- C#中禁止跨執行緒直接訪問控制元件
- InvokeRequired是為了解決這個問題而產生的
- 當一個控制元件的InvokeRequired屬性值為真時，說明有一個建立它以外的執行緒想訪問它
- 此時它將會在內部呼叫new MethodInvoker(LoadGlobalImage)來完成下面的步驟
- 這個做法保證了控制元件的安全

你可以這樣理解，有人想找你借錢，他可以直接在你的錢包中拿，這樣太不安全，因此必須讓別人先要告訴你，你再從自己的錢包把錢拿出來借給別人，這樣就安全了
 

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
[2]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.control.invokerequired?view=windowsdesktop-6.0
[3]:https://www.796t.com/content/1549952496.html