# csharp_example

## ListBox

### 常用屬性

- SelectionMode
None
One:          只能選一個項目(預計)
MultiSimple:  不需要按<shift>或<ctrl>鍵才能多選
MultiExtened: 需要按<shift>或<ctrl>鍵才能多選

### 常用方法

Items.Add(項目字串)
Items.AddRange(字串陣列名稱)
Items.Insert()
Items.Clear()
Items.Remove(項目字串)
 - Items.Remove(LstBox.SelectedItem)

- 控制項目其它常用方法
SetSelected(註標值，true | false) 
 - SetSelected(0,true)
ClearSelected()
GetSelected(index) : 為true表示有被點選
Contains(字串): 檢查此字串是否存在


### 範例如下

![Imgur](https://i.imgur.com/EI9CUud.gifv)	