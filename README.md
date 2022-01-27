# csharp_example

## OpenFileDialog 及 SaveFileDialog

兩個有關檔案的工具，可以快速建立開檔和存檔的介面  
兩個對話方塊控制項都是屬於幕後執行的控制項，必須使用ShowDialog()方法  

### 1-1 屬性

FileName: 取得檔案對話方塊中的選取的檔名(D:\tmp\pic.PNG)  
Multiselect: 是否可以選取多個檔案,預計值為False(僅OpenFileDialog)  
InitialDirectory: 起始檔案目錄  
Filter: 篩選字串，預設值為空字串  

```
openFileDialog1.InitialDirectory="C:\\test";
```

Filter用法如下  

```
"顯示文字1|規則1|顯示文字2|規則2.."

openFileDialog1.Filter = "JPEG|*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png";

若選副檔txt和所有檔案如下
openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
```


```
filename:D:\tmp\pic.PNG
filename:D:\tmp\pic3.PNG
filename:D:\tmp\pic2.PNG
save filename:D:\tmp\test2.jpg
```

### 範例如下

![image](https://github.com/erwinchang/csharp_example/blob/ch10-01-MultiForm/gif/openFileDialog.gif)