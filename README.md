# csharp_example


## WPF

4.3.1 xType

如何使用自定Button物件，通過xType開啟特定windows

1.建立Windows1

採用新增wpf windwos1  
```
<Window x:Class="WpfApp1.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="Window1" Height="170" Width="200">
    <StackPanel Background="LightBlue">
        <TextBlock Margin="5"/>
        <TextBlock Margin="5"/>
        <TextBlock Margin="5"/>
        <Button Content="OK" Margin="5"/>
    </StackPanel>
</Window>
```

2.建立MyButton如下

this.UserWindowType由自定的UserWindowType取得要開啟的window名稱  
```
    public class MyButton: Button
    {
        public Type UserWindowType { get; set; }
        protected override void OnClick()
        {
            base.OnClick();
            Window win = Activator.CreateInstance(this.UserWindowType) as Window;
            if(win != null)
            {
                win.ShowDialog();
            }
        }
    }
```

3.設定主的xaml如下

設定local  
通過x:Type自定UserWindowType為Window1
```
<Window x:Class="WpfApp1.MainWindow"
    xmlns:local="clr-namespace:WpfApp1" 

    <StackPanel>
        <local:MyButton Content="Show" UserWindowType="{x:Type TypeName=local:Window1}" Margin="5" />
    </StackPanel>
```

<a href="https://imgur.com/qRWfzBz"><img src="https://i.imgur.com/qRWfzBz.png" title="source: imgur.com" width="400px"/></a>

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

