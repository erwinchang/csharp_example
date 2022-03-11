# csharp_example

## [如何從 Microsoft Visual C#.NET 自動化 Microsoft Excel][1]

執行結果如下

<a href="https://imgur.com/IYM1gMv"><img src="https://i.imgur.com/IYM1gMv.png" title="source: imgur.com" width="400px" /></a>


由c#程式產生，資料範圍沒有內容，但打印程式ranger是正確的

<a href="https://imgur.com/aMwaDm9"><img src="https://i.imgur.com/aMwaDm9.png" title="source: imgur.com" width="400px" /></a>



採用VBA設定方式如下
```
    ActiveChart.ChartArea.Select
    Application.CutCopyMode = False
    Application.CutCopyMode = False
    ActiveChart.SetSourceData Source:=Range("E2:H6")
    ActiveChart.FullSeriesCollection(1).XValues = "=工作表1!$A$2:$A$6"
    ActiveChart.FullSeriesCollection(1).Name = "=""Q1"""
    ActiveChart.FullSeriesCollection(2).Name = "=""Q2"""
```    


[1]:https://docs.microsoft.com/zh-tw/previous-versions/office/troubleshoot/office-developer/automate-excel-from-visual-c