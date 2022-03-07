# csharp_example

## XSLTC

如何使用xslt將xml轉成為html

[作法：使用組件執行 XSLT 轉換][1]



### 1 執行xsltc產生參考用dll

由電腦中可到找到xsltc如下
```
C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsltc.exe
```

1-1 產生dll
會建立兩個名為 Transform.dll 和 Transform_Script1.dll 的組件
```
xsltc /settings:script+ Transform.xsl  
```

### 2 C# 執行xsltc載入

```
//Create a new XslCompiledTransform and load the compiled transformation.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load(typeof(Transform));

String srcXmlFile = @"D:\gitWork\test-xml-xslt\books.xml";
String resHtmlFile = @"D:\gitWork\test-xml-xslt\discount_books.html";
xslt.Transform(srcXmlFile, resHtmlFile);
```

----------------

### xml內容如下

<a href="https://imgur.com/ksuCgRw"><img src="https://i.imgur.com/ksuCgRw.png" title="source: imgur.com"  width="400px" /></a>

###　產生html如下

<a href="https://imgur.com/qPLNfqU"><img src="https://i.imgur.com/qPLNfqU.png" title="source: imgur.com" width="400px" /></a>


--------


```
Copyright (C) Microsoft Corporation. 著作權所有，並保留一切權利。

xsltc [選項] [/class:<名稱>] <原始程式檔> [[/class:<名稱>] <原始程式檔>...]

                      XSLT 編譯器選項

                        - 輸出檔 -
/out:<file>             指定二進位輸出檔的名稱 (預設: 第一個原始程式檔的名稱)
/version:<version>      指定組件版本
/delaysign[+|-]         僅使用強式名稱金鑰的公用部分延遲簽署組件
/keyfile:<file>         指定強式名稱金鑰檔
/keycontainer:<string>  指定強式名稱金鑰容器
/platform:<string>      限制此程式碼可以在哪一個平台上執行: x86、Itanium、x64 或 anycpu，這是預設值

                        - 資源 -
/win32res:<file>        指定 Win32 資源檔 (.res)

                        - 程式碼產生 -
/class:<name>           指定已編譯之樣式表的類別名稱 (簡短形式: /c)
/debug[+|-]             發出偵錯資訊
/debug:{full|pdbonly}   指定偵錯類型 ('full' 是預設值，它可啟用附加偵錯工具)
/settings:<list>        以下列格式指定安全性設定 (dtd|document|script)[+|-],...
                        Dtd 可在樣式表中啟用 DTD，document 可啟用 document() 函式，script 可啟用 <msxsl:script> 元素

                        - 其他 -
@<file>                 從文字檔插入命令列設定
/help                   顯示此使用方式訊息 (簡短形式: /?)
/nologo                 隱藏編譯器著作權訊息

C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools>
```

https://www.cnblogs.com/chenxizhang/archive/2009/05/24/1488492.html



[1]:https://docs.microsoft.com/zh-tw/dotnet/standard/data/xml/how-to-perform-an-xslt-transformation-by-using-an-assembly