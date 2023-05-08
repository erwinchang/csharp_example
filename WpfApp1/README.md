## ListView Drag Drop

[WPF listview Drag & Drop a Custom Item][1]


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