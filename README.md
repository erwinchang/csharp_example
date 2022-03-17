# csharp_example

## 如何使用c#建立excel vba程式


### 1-1 .xlsm建立方式

注意:excel安全性，依每個excel設定而不同
建立的template要先設定把vba都開打這樣子c#程式才能寫入

程序如下
1.先建立excel(.xlsx)
2.別存新檔(.xlsm)，一定要.xlsm才能建立module程式 
3.設定.xlsm開啟巨集功能，才能執行巨集 =>讓c#可以寫入excel程式，讓excel可以執行巨集

1.開啟信任存取VBA專案物件模型
需要開啟，不然無在excel增加程式
<a href="https://imgur.com/dhg48AT"><img src="https://i.imgur.com/dhg48AT.png" title="source: imgur.com" width="400px" /></a>

### 1-2 如何建立template內部sub function

記得要建立在module裡面(即模組Module裡面)
<a href="https://imgur.com/UOI4L6O"><img src="https://i.imgur.com/UOI4L6O.png" title="source: imgur.com" width="400px" /></a>

若是建立sheet內，使用巨集需採用(sheet!test_click)如下
<a href="https://imgur.com/bLAFVvc"><img src="https://i.imgur.com/bLAFVvc.png" title="source: imgur.com" width="400px" /></a>

### 執行如下

<a href="https://imgur.com/WIvng1W"><img src="https://i.imgur.com/WIvng1W.png" title="source: imgur.com" width="400px" /></a>