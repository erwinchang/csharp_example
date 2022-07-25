# csharp_example


## WPF

1.先設定

```
xmlns:sys="clr-namespace:System;assembly=mscorlib"
```

2.再設定變數  

使用剛剛設定sys來建立String  
使用x:Key方式定義變數   

```
<Window.Resources>
    <sys:String x:Key="myString">Hello WPF Resource!</sys:String>
</Window.Resources>
```

3.使用變數

在xaml使用方式採用ResourceKey  

```
<TextBox Text="{StaticResource ResourceKey=myString}" Margin="5"/>

```

在c#裡面方式採用FindResource  

```

string 採用str = this.FindResource("myString") as string;
this.textBox1.Text = str;
```

<a href="https://imgur.com/BLW5fHm"><img src="https://i.imgur.com/BLW5fHm.png" title="source: imgur.com" /></a>

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

1.下例用法是一樣的

```
<Button x:Name="btn" />
```
```
<Button Name="btn" />
```