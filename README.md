# csharp_example


## WPF

5.3.3 ItemControl類

DisplayMemberPath設定LisBox顯示的數據

ItemsControl使用對應的ItemContainer自動對應數據如下  

1.建立ListBox
```
<Grid>
    <ListBox x:Name="listBoxEmplyee"/>
</Grid>
```

2.建立數據及連結如下
```
List<Employee> empList = new List<Employee>()
{
    new Employee(){Id=1,Name="Tim",Age=30},
    new Employee(){Id=2,Name="Tom",Age=26},
    new Employee(){Id=3,Name="Guo",Age=26},
    new Employee(){Id=4,Name="Yan",Age=25},
    new Employee(){Id=5,Name="Owen",Age=30}
};
this.listBoxEmplyee.DisplayMemberPath = "Name";
this.listBoxEmplyee.SelectedValuePath = "Id";
this.listBoxEmplyee.ItemsSource = empList;
```

<a href="https://imgur.com/gCyDH12"><img src="https://i.imgur.com/gCyDH12.png" title="source: imgur.com" /></a>

----------

ItemsControl如下  

| 名稱 | 對應的Container|
|:-----|:--------------|
|ComboxBox | ComboxBoxItem |
|ContextMenu | MenuItem |
|ListBox | ListBoxItem |
|ListView | ListViewItem |
|Menu | MenuItem |
|StatuBar | StatusBarItem |
|TabControl | TabItem |
|TreeView | TreeViewItem |




