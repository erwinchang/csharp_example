## ListView Drag Drop

[WPF listview Drag & Drop a Custom Item][1]

[WPF 中的拖放功能支援][2]
在拖放作業中，會使用 DataObject 來儲存資料
拖曳來源會呼叫靜態 DragDrop.DoDragDrop 方法，並將所傳送的資料傳遞給該方法，來啟始拖放作業


注意當執行DragDrop.DoDragDrop，之後就是DragEnter
```
[2023/05/08 11:59:12.597] [MouseMove] mousePos:278,280, minH:4, minV:4, diff:-278,-280
[2023/05/08 11:59:12.714] [PreviewMouseLeftButtonDown] 278,280                               #左鍵按下
[2023/05/08 11:59:13.724] [MouseMove] mousePos:278,281, minH:4, minV:4, diff:0,-1
[2023/05/08 11:59:13.738] [MouseMove] mousePos:278,282, minH:4, minV:4, diff:0,-2
[2023/05/08 11:59:13.744] [MouseMove] mousePos:278,283, minH:4, minV:4, diff:0,-3
[2023/05/08 11:59:13.763] [MouseMove] mousePos:278,284, minH:4, minV:4, diff:0,-4
[2023/05/08 11:59:13.774] [MouseMove] mousePos:278,285, minH:4, minV:4, diff:0,-5
[2023/05/08 11:59:13.793] [DragEnter]                                                        #執行DragDrop.DoDragDrop
[2023/05/08 11:59:13.866] [DragEnter]
[2023/05/08 11:59:13.873] [DragEnter]
[2023/05/08 11:59:13.898] [DragEnter]
[2023/05/08 11:59:13.921] [DragEnter]
[2023/05/08 11:59:17.915] [Drop]                                                             #放開左鍵
[2023/05/08 11:59:17.939] [MouseMove] mousePos:271,309, minH:4, minV:4, diff:7,-29
[2023/05/08 11:59:18.322] [MouseMove] mousePos:270,309, minH:4, minV:4, diff:8,-29
```

DragEnter Event. Occurs when mouse pointer enter into UIElement marked as drop target while drag-and-drop is in progress.
DragEnter   This event occurs when an object is dragged into the drop target's boundary. This is a bubbling event.
DragLeave   This event occurs when an object is dragged out of the drop target's boundary. This is a bubbling event.
DragOver    This event occurs continuously while an object is dragged (moved) within the drop target's boundary. This is a bubbling event.
Drop    This event occurs when an object is dropped on the drop target. This is a bubbling event.


採用Global.listPlan移動
```
private void btnMoveUp_Click(object sender, RoutedEventArgs e)
{
    ListTestPlan item = null;
    int index = -1;

    if (listViewTestPlan.SelectedItems.Count != 1) return;
    item = (ListTestPlan)listViewTestPlan.SelectedItems[0];
    index = Global.listPlan.IndexOf(item);
    if (index > 0)
    {
        Global.listPlan.Move(index, index - 1);
    }
}
```
[1]:https://www.codeproject.com/Articles/1236549/Csharp-WPF-listview-Drag-Drop-a-Custom-Item
[2]:https://learn.microsoft.com/zh-tw/dotnet/desktop/wpf/advanced/drag-and-drop-overview?view=netframeworkdesktop-4.8