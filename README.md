# csharp_example


## WPF

4.3.5 x:Static

如何取得class裡面變數
採用x:Static方式

```
    public partial class MainWindow : Window
    {
        public static string WindowTitel = "Title Test11";
        public static string ShowText { get { return "Show Test22"; } }
```

<a href="https://imgur.com/iuMRIjd"><img src="https://i.imgur.com/iuMRIjd.png" title="source: imgur.com" /></a>

---------

## x namespace用法

```
<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
```

|定義 | 種類 |
|:----|:----|
| x:Array | 標簽擴展 |
| x:Class | Attribute |
| x:ClassModifier | Attribute |
| x:Code | XAML指令元素 |
| x:Name | Attribute |
| x:Key  | Attribute，用於定義變數 |
| x:FieldModifier | Attribute，用於定義public等 |
| x:Type | 標簽擴展 |

