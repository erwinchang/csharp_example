# csharp_example

## notifyicon



menuStrip,contextmenustrip,notifyicon如下

<a href="https://imgur.com/Gh3AJAk"><img src="https://i.imgur.com/Gh3AJAk.png" title="source: imgur.com" width="400px" /></a>

<a href="https://imgur.com/Gij87DB"><img src="https://i.imgur.com/Gij87DB.png" title="source: imgur.com" width="400px" /></a>


參考範例來源   
[NotifyIcon Class][7]  

------------

### 如何設定min時才移到右下角

[讓視窗縮小到工具列吧-NotifyIcon][8]

```
private void Form1_SizeChanged(object sender, EventArgs e)
{
    if (this.WindowState == FormWindowState.Minimized)
    {
        this.Hide();
        this.notifyIcon1.Visible = true;
    }
}
private void notifyIcon1_DoubleClick(object sender, EventArgs e)
{
    this.Show();
    this.WindowState = FormWindowState.Normal;
    this.notifyIcon1.Visible = false;
}
```

---------

###　其它說明

[ContextMenu 類別][1]  
- 代表捷徑功能表  
- 此類別在 .NET Core 3.1 和更新版本中無法使用。 請改用 ContextMenuStrip ，以取代和擴充 ContextMenu 控制項   


[MenuItem 類別][2]  
- 表示 MainMenu 或 ContextMenu 中顯示的個別項目  
- 此類別在 .NET Core 3.1 和更新版本中無法使用。 請 ToolStripMenuItem 改用 ，以取代 MenuItem 控制項  

[IContainer 介面][3]  
- 提供容器的功能。 容器是邏輯上包含零個或多個元件的物件  
- 若要成為容器，類別必須實 IContainer 作 介面，其支援新增、移除和擷取元件的方法  
- 容器是封裝及追蹤零個或多個元件的物件  


[Windows Form Designer 續篇 -- components][4]  

所以要成為一個容器至少要具備幾項要求：  
- 可以加個物件進來容器  
- 可以把一個物件從容器中移除  
- 要可以釋放資源，意即要實做Dispose方法  
- 要可以取得容器內物件的集合  



[ContextMenu 元件概觀 (Windows Form)][5]  
- 雖然 MenuStrip 以及 ContextMenuStrip 取代和新增功能至舊版的 MainMenu 和 ContextMenu 控制項，但如果您選擇， MainMenuContextMenu 則會保留以提供回溯相容性和未來用途  
- 使用 Windows Forms ContextMenu 元件，您可以為使用者提供與所選物件相關聯之常用命令的容易存取快捷方式功能表  

[ContextMenuStrip 控制項概觀][6]  
- 當使用者按一下滑鼠右鍵時，快捷方式功能表（也稱為快顯功能表）會出現在滑鼠位置。 快速鍵 功能表 提供工作區的選項，或滑鼠指標位置的控制項  

[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.contextmenu?view=netframework-4.8
[2]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.menuitem?view=netframework-4.8
[3]:https://docs.microsoft.com/zh-tw/dotnet/api/system.componentmodel.icontainer?view=net-6.0
[4]:https://dotblogs.com.tw/billchung/2011/01/09/20673
[5]:https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/contextmenu-component-overview-windows-forms?view=netframeworkdesktop-4.8
[6]:https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/contextmenustrip-control-overview?view=netframeworkdesktop-4.8
[7]:https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.notifyicon?view=netframework-4.8
[8]:https://dotblogs.com.tw/jimmyyu/2009/09/21/10733