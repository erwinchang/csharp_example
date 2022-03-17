# csharp_example

## 範例2

1. 依tempalte產生新的excel  
2. 執行template裡面的vba程式  

程序  
1.copy template excel to new excel  
2.新增config分頁，新增raw data(未新增)  
3.執行 template裡面的vba產生passed/failed(未新增)  

### 參考來源:

[how to call excel macros programmatically in C#? ][1]  
[Run a Macro from C#][2]  
[呼叫Excel VBA Macro][3]  


----------

## 範例3

[Kill Process Excel C#][4]  
[Call a function in another Excel 2010 AddIn (.xlam)][5]

改用call xlam方式

```
//注意要先把檔案copy到D:\Admin\Documents\USIToolV00_0101.xlam才能正確執行到 why?
oXL.Run("USIToolV00_0101.xlam!test_autorun")
```


[1]:https://social.msdn.microsoft.com/Forums/lync/en-US/2e33b8e5-c9fd-42a1-8d67-3d61d2cedc1c/how-to-call-excel-macros-programmatically-in-c?forum=exceldev
[2]:https://stackoverflow.com/questions/38997796/run-a-macro-from-c-sharp
[3]:https://dotblogs.com.tw/killysss/2015/10/01/153471
[4]:https://stackoverflow.com/questions/9316141/kill-process-excel-c-sharp
[5]:https://www.mrexcel.com/board/threads/call-a-function-in-another-excel-2010-addin-xlam.678608/