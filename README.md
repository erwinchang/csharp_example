# csharp_example

## 在另一個thread要去設定UI上面的值

1.先判斷InvokeRequired  
2.通過Invoke去設定如下  

```
private delegate void AddTextDelegate(string text);
public void AddText(string text)
{
    if (ltbViewText.InvokeRequired)
    {
        AddTextDelegate td = AddText;
        ltbViewText.Invoke(td, text);
    }
    else
    {
        ltbViewText.Items.Add(text);
    }
}
```

範例如下

<a href="https://imgur.com/kuRyu3E"><img src="https://i.imgur.com/kuRyu3E.png" title="source: imgur.com" width="400px" /></a>

### 其它說明


[背景執行緒與前景執行緒的差別][1]

Thread.IsBackground=false 
此時為背景，好處若主程式離開，此時背景程式會馬上自動關閉離開
因此主程式可以加入Join來確保Thread有正常執行完成

Thread.IsBackground=true
此時為前景，好處若主程式離開，此時會等Thread執行完才會離開

[1]:https://dotblogs.com.tw/yc421206/2011/01/04/20574