# csharp_example

## [ApplicationContext 類別][1]

碼範例會顯示兩個表單，並在兩個表單關閉時結束應用程式
當應用程式啟動和結束時，會記住每個表單的位置([Control.Bounds 屬性][3])
表單位置資料會儲存在標題 Appdata.txt 為 的檔案中，該檔案是由 所決定的位置所 UserAppDataPath 建立

- [Control.Bounds 屬性][3]
取得或設定控制項 (包括其非工作區項目) 相對於父控制項之大小和位置 (單位為像素)

----------

### 說明

1.建立MyApplicationContext，使用Applicatin.Run(MyApplicationContext)
2.由MyApplicationContext生成Form
3.MyApplicationContext需要知道是否全部的Form都已關閉，此時才結束應用程式
4.結束應用程式會記錄每個Form位置及大小，以便下次打開時設定

將相關資料儲存在下例位置
```
private FileStream _userData;
_userData = new FileStream(Application.UserAppDataPath + "\\appdata.txt", FileMode.OpenOrCreate);


UserAppDataPath:C:\Users\twxxxx\AppData\Roaming\csharp_example\csharp_example\1.0.0.0
```

----------

### [c#利用ApplicationContext类 同时启动双窗体的实现][2]  

使用Application.Run有下例三種方式

- 1.不帶參數

- 2.使用Form 

```
Application.Run(System.Windows.Forms.Form mainForm)
```
只需要吧希望作为主窗口的Form实例（包括从Form类派生的类）传递给mianForm参数即可
一旦mainForm关闭，整个消息循环就会退出，Run方法返回，应用程序就会退出

- 3.使用ApplicationContext 

```
static void Main(string[] args)
{
    MyApplicationContext context = new MyApplicationContext();
    Application.Run(context);
}
```

这是Run方法中重载最灵活的
ApplicationContext类也允许设置一个Form实例制作为主窗口，也可以不设置主窗口
这个Run方法会在ApplicationContext对象进行消息循环。
调用ApplicationContext类的ExitThread方法会导致ApplicationContext上的消息循环终止


[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.applicationcontext?view=windowsdesktop-6.0
[2]:https://www.cnblogs.com/mq0036/p/10503164.html
[3]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.control.bounds?view=windowsdesktop-6.0