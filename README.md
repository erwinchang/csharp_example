# csharp_example

## DoEvents

[Application.DoEvents強制跳脫迴圈][1]

通常在程式在迴圈中，就必須將迴圈執行完才能離開迴圈
C# Application.DoEvents強制跳脫迴圈

想要中途離開迴圈的話有兩種使用方式
1.使用多執行序
2.使用DoEvents()

DoEvents 就是當系統運行到Application.DoEvents() 時 ，會將頁面的控制權還給使用者,然後再繼續往下執行

範列:
在while中若沒有Application.DoEvents(), 將不會有while現像(why?)


[Application.DoEvents Method][2]
Processes all Windows messages currently in the message queue.

[C# 好用的DoEvent ,winForm][3]

[使用Application.DoEvents()][4]
使用DoEvents在編寫自己的模態迴圈時阻止其使用者介面凍結
它確實做到了；它分派(dispatch)Windows訊息並獲取所有傳遞的繪畫請求

[1]:https://lifewth.com/c-application-doevents/
[2]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.application.doevents?view=windowsdesktop-6.0
[3]:http://wayneprogramcity.blogspot.com/2014/05/c-doevent-winform.html
[4]:https://www.796t.com/post/MWM4a28=.html