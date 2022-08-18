# csharp_example

## keyDown Event Handle

注意:可以抓到Ctrl鍵，但不能抓到數字鍵

```
_mainForm.KeyDown += MainFormVM_KeyDown;

private void MainFormVM_KeyDown(object sender, KeyEventArgs e)
{
    Console.WriteLine(e.KeyValue);
}
```

### 注意當Form加入GroupBox就會被GroupBox_KeyDown取代，因此From_KeyDown會抓不到


### 參考:

- [how to assign one method to all keypress event of textboxes][1]  
- [Catch/Handle Keydown Event From All Control Inside Groupbox][2]  
- [VB.NET 鍵盤事件介紹 (KeyPress、KeyDown 和 KeyUp 事件)][3]  

[1]:https://www.codeproject.com/Questions/831952/how-to-assign-one-method-to-all-keypress-event-of?tab=mostrecent
[2]:https://stackoverflow.com/questions/49361101/catch-handle-keydown-event-from-all-control-inside-groupbox
[3]:https://tsuozoe.pixnet.net/blog/post/19733703