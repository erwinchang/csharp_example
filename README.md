# csharp_example

## ch07 / ListView

### ListBox清單方塊

文字項目清單  
讓使用者可以從清單中選取適當的項目  
屬性  
 - SelectionMode:None,One,MultiSimple,MultiExtended

![Imgur](https://i.imgur.com/5BDLLFE.png)



### ListView清單檢視  

比LisBox清單控制項強大  
還可以用圖示來顯示  
清單檢視控制有一個特別稱為 "啟動"  

設定啟動方式 

```
LstvBooks.Activation = ItemActivation.TwoClick;
```

#### 1-1 屬性

|屬性|說明|
|:---|:---|
|Activation | 設定啟動項目的方式, 屬性值 |
|           | 1.Standard (快按兩下，預計值) |
|           | 2.OneClick / 3.TwoClick |
|CheckBoxs  | 設定是否顯示核取方塊,預計是False是不顯示 |
|Items      | 設定和讀取控制項中項間的集合|
|Items[].SubItems | 指定index中的子項集合|
|Items[].ImageIndex | 指定index中的影像 |
|View | 設定值如下 |
|     | LargetIcon(大圖示) |
|     | Detail(詳細清單) |
|     | SmallIcon(小圖示) |
|     | List(清單) |
|     | Tiel(大圖示程詳細清單) |


#### 1-2 方法

設定ListViewBox流程如下  

流程如下  
1.先設定Columns  
2.BeginUpdate 停止控制項重繪  
3.增加資料(SubItem.add)  
4.EndUpdate 進行重繪  


1-2-1 Columns.Add(欄位名稱字串,欄位寬度)  

```
LstvBooks.Columns.Add("書名", 100);
LstvBooks.Columns.Add("作者", 60);
LstvBooks.Columns.Add("類別", 60);
```            
1-2-2 SubItems.Add(資料字串)  

1-2-3 BeginUpdate/EndUpdate  



設定ListViewItem如下  

```
for(int i =0; i<bname.Length; i++)
{
    ListViewItem lvi = new ListViewItem(bname[i]);
    lvi.SubItems.Add(author[i].ToString());
    lvi.SubItems.Add(kind[i]);
    LstvBooks.Items.Add(lvi);
    LstvBooks.Items[i].ImageIndex = i;
}
```


設定CheckBoxs如下  

![Imgur](https://i.imgur.com/ySFci8c.png)

### 範例如下

![image](https://github.com/erwinchang/csharp_example/blob/ch07_ListView/gif/ListView.gif)

