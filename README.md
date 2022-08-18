# csharp_example

## 1 keyDown Event Handle

注意:可以抓到Ctrl鍵，但不能抓到數字鍵

```
_mainForm.KeyDown += MainFormVM_KeyDown;

private void MainFormVM_KeyDown(object sender, KeyEventArgs e)
{
    Console.WriteLine(e.KeyValue);
}
```

## 2 注意當Form加入GroupBox就會被GroupBox_KeyDown取代，因此From_KeyDown會抓不到

解決方式  
- [Windows.Form not fire keyDown event][4]  
設定this.KeyPreview = true即可  

- [Form.KeyPreview 屬性][5]
取得或設定值，指出表單是否要在事件傳送至焦點所在的控制項之前，接收按鍵事件


## 3 如何抓取Alt+Ctrl+Enter key

[Handle the KeyDown Event when ALT+KEY is Pressed][6]
[Windows Forms - Enter keypress activates submit button?][7]
[KeyEventArgs.Handled 屬性][8]


KeyEventArgs.Handled
true : 表示略過控制項的預設處理
false: 表示將事件直接傳遞至預設的控制項處理常式


```
private void MainFormVM_KeyDown(object sender, KeyEventArgs e)
{
    if (e.Alt && e.Control && (e.KeyCode == Keys.Enter))
    {
        Console.WriteLine("TEST");
        e.Handled = true;
```


## 4 參考:

- [how to assign one method to all keypress event of textboxes][1]  

- [Catch/Handle Keydown Event From All Control Inside Groupbox][2]  

- [VB.NET 鍵盤事件介紹 (KeyPress、KeyDown 和 KeyUp 事件)][3]  
當輸入一個字元，則此三個事件發生的順序為：
KeyDown 事件 ---> KeyPress 事件 ---> KeyUp 事件

- [Windows.Form not fire keyDown event][4]
- [Form.KeyPreview 屬性][5]

[1]:https://www.codeproject.com/Questions/831952/how-to-assign-one-method-to-all-keypress-event-of?tab=mostrecent
[2]:https://stackoverflow.com/questions/49361101/catch-handle-keydown-event-from-all-control-inside-groupbox
[3]:https://tsuozoe.pixnet.net/blog/post/19733703
[4]:https://stackoverflow.com/questions/3334927/windows-form-not-fire-keydown-event
[5]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.form.keypreview?view=windowsdesktop-6.0
[6]:https://stackoverflow.com/questions/2146970/handle-the-keydown-event-when-altkey-is-pressed
[7]:https://stackoverflow.com/questions/164903/windows-forms-enter-keypress-activates-submit-button
[8]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.keyeventargs.handled?view=windowsdesktop-6.0