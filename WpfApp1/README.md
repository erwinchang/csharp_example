## ListView Drag Drop

[WPF listview Drag & Drop a Custom Item][1]

[WPF 中的拖放功能支援][2]
在拖放作業中，會使用 DataObject 來儲存資料
拖曳來源會呼叫靜態 DragDrop.DoDragDrop 方法，並將所傳送的資料傳遞給該方法，來啟始拖放作業


注意當執行DragDrop.DoDragDrop，之後就是DragEnter
```
[2023/05/08 16:02:24.646] [MouseMove] mousePos:229,250, minH:4, minV:4, diff:-229,-250
[2023/05/08 16:02:24.706] [PreviewMouseLeftButtonDown] 229,250                            #左鍵按下
[2023/05/08 16:02:24.707] [GetMousePosition] x:325,307, 219,40
[2023/05/08 16:02:24.708] [GetMousePosition] x:325,307, 217,18
[2023/05/08 16:02:24.708] [IndexUnderDragCursor] indexUnderDragCursor:0
[2023/05/08 16:02:25.057] [MouseMove] mousePos:229,251, minH:4, minV:4, diff:0,-1
[2023/05/08 16:02:25.063] [MouseMove] mousePos:230,252, minH:4, minV:4, diff:-1,-2
[2023/05/08 16:02:25.068] [MouseMove] mousePos:230,253, minH:4, minV:4, diff:-1,-3
[2023/05/08 16:02:25.071] [MouseMove] mousePos:231,253, minH:4, minV:4, diff:-2,-3
[2023/05/08 16:02:25.073] [MouseMove] mousePos:231,254, minH:4, minV:4, diff:-2,-4
[2023/05/08 16:02:25.077] [MouseMove] mousePos:231,255, minH:4, minV:4, diff:-2,-5
[2023/05/08 16:02:25.086] [DragEnter]                                                   #執行DragDrop.DoDragDrop
[2023/05/08 16:02:25.091] [DragEnter]
[2023/05/08 16:02:25.098] [DragEnter]
[2023/05/08 16:02:25.102] [DragEnter]
[2023/05/08 16:02:25.105] [DragEnter]
[2023/05/08 16:02:25.291] [DragEnter]
[2023/05/08 16:02:25.302] [DragEnter]
[2023/05/08 16:02:25.671] [Drop]                                                        #放開左鍵
[2023/05/08 16:02:25.689] [MouseMove] DoDragDrop Finish                                 #回到MouseMove執行DragDrop.DoDragDrop完成，因為MouseMove在等DoDragDrop
[2023/05/08 16:02:25.692] [MouseMove] mousePos:237,298, minH:4, minV:4, diff:-8,-48
[2023/05/08 16:02:26.061] [MouseMove] mousePos:237,299, minH:4, minV:4, diff:-8,-49
[2023/05/08 16:02:26.076] [MouseMove] mousePos:236,299, minH:4, minV:4, diff:-7,-49
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