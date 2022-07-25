# csharp_example


## WPF

4.3.4 x:Array

```
<Grid Background="LightBlue">
    <ListBox Margin="5">
        <ListBox.ItemsSource>
            <x:Array Type="sys:String">
                <sys:String>Tim</sys:String>
                <sys:String>Tom</sys:String>
                <sys:String>Victor</sys:String>
            </x:Array>
        </ListBox.ItemsSource>
    </ListBox>
</Grid>
```

<a href="https://imgur.com/H9toZtv"><img src="https://i.imgur.com/H9toZtv.png" title="source: imgur.com" /></a>

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

