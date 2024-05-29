# csharp_example

### Ex01 [Word合併列印實作][2]

- 加入[Microsoft.Office.Interop.Excel][1]參考


word記錄
```
Sub test2()
'
' test2 巨集
'
'
    ActiveDocument.MailMerge.MainDocumentType = wdMailingLabels
    ActiveDocument.MailMerge.MainDocumentType = wdCatalog
    ActiveDocument.MailMerge.OpenDataSource Name:="D:\template.txt", _
        ConfirmConversions:=False, ReadOnly:=False, LinkToSource:=True, _
        AddToRecentFiles:=False, PasswordDocument:="", PasswordTemplate:="", _
        WritePasswordDocument:="", WritePasswordTemplate:="", Revert:=False, _
        Format:=wdOpenFormatAuto, Connection:="", SQLStatement:="", SQLStatement1 _
        :="", SubType:=wdMergeSubTypeOther
    ActiveDocument.MailMerge.Fields.Add Range:=Selection.Range, Name:="產品名稱"
    Selection.TypeParagraph
    ActiveDocument.MailMerge.Fields.Add Range:=Selection.Range, Name:="產品單價"
    Selection.TypeParagraph
    ActiveDocument.MailMerge.Fields.Add Range:=Selection.Range, Name:="產品內容"
    Selection.TypeParagraph
    ActiveDocument.MailMerge.Fields.Add Range:=Selection.Range, Name:="產品介紹"
    Selection.TypeParagraph
    ActiveDocument.MailMerge.DataSource.ActiveRecord = wdNextRecord
    ActiveDocument.MailMerge.DataSource.ActiveRecord = wdPreviousRecord
    With ActiveDocument.MailMerge
        .Destination = wdSendToNewDocument
        .SuppressBlankLines = True
        With .DataSource
            .FirstRecord = wdDefaultFirstRecord
            .LastRecord = wdDefaultLastRecord
        End With
        .Execute Pause:=False
    End With
    Windows("template1.docx").Activate
End Sub
```

設定版寬
```
    With ActiveDocument.PageSetup
        .LineNumbering.Active = False
        .Orientation = wdOrientPortrait
        .TopMargin = CentimetersToPoints(0)
        .BottomMargin = CentimetersToPoints(0)
        .LeftMargin = CentimetersToPoints(0.6)
        .RightMargin = CentimetersToPoints(0.6)
        .Gutter = CentimetersToPoints(0)
        .HeaderDistance = CentimetersToPoints(1.5)
        .FooterDistance = CentimetersToPoints(1.75)
        .PageWidth = CentimetersToPoints(21)
        .PageHeight = CentimetersToPoints(29.7)
        .FirstPageTray = wdPrinterDefaultBin
        .OtherPagesTray = wdPrinterDefaultBin
        .SectionStart = wdSectionNewPage
        .OddAndEvenPagesHeaderFooter = False
        .DifferentFirstPageHeaderFooter = False
        .VerticalAlignment = wdAlignVerticalTop
        .SuppressEndnotes = False
        .MirrorMargins = False
        .TwoPagesOnOne = False
        .BookFoldPrinting = False
        .BookFoldRevPrinting = False
        .BookFoldPrintingSheets = 1
        .GutterPos = wdGutterPosLeft
        .LayoutMode = wdLayoutModeLineGrid
    End With
```

插入圖片
```
Sub test1_3()
'
' test1_3 巨集
'
'
    Windows("template2.docx  -  相容模式").Activate
    ActiveDocument.Shapes("圖片 2").Select
    Windows("test2.docx").Activate
    Selection.InlineShapes.AddPicture FileName:="D:\logo.png", LinkToFile:= _
        False, SaveWithDocument:=True
End Sub
```


### Ex03 [automate-word-mail-merge-using-visual-c][3]

[1]:https://jengting.blogspot.com/2015/08/c-microsoftofficeinteropexcel.html
[2]:https://www.cc.ntu.edu.tw/chinese/epaper/home/News_Content_n_103858_s_220288.html
[3]:https://learn.microsoft.com/zh-tw/previous-versions/office/troubleshoot/office-developer/automate-word-mail-merge-using-visual-c