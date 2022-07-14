# csharp_example

## 採用BindingList來更新ListBox

1.定義```BindingList<Part> listOfParts```
2.定義ListBox顯示內容  
- 設定物件Part的PartName為顯示  
- listBox1.DisplayMember = "PartName";  

初始化  
```
listOfParts = new BindingList<Part>();

listOfParts.Add(new Part("Widget", 1234));
listOfParts.Add(new Part("Gadget", 5647));
listBox1.DataSource = listOfParts;
listBox1.DisplayMember = "PartName";
```	

Add  
對listOfParts操作，將會自動更新ListBox  
```
listOfParts.Add(new Part("T11", 5647));
```

Clear  
```
listOfParts.Clear();
```

參考來源:  
- [BindingList<T> Class][1]  

[1]:https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.bindinglist-1?redirectedfrom=MSDN&view=net-6.0