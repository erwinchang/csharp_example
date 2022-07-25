# csharp_example


## WPF

###　採用stackPanel.Children[0]方式

```
<StackPanel>
    <TextBox Margin="5"/>
    <Button Content="OK" Margin="5" Click="Button_Click"/>
</StackPanel>
```

採用stackPanel.Children[0]來取得TextBox物件
```
private void Button_Click(object sender, RoutedEventArgs e)
{
    StackPanel stackPanel = this.Content as StackPanel;
    TextBox textBox = stackPanel.Children[0] as TextBox;
    if (string.IsNullOrEmpty(textBox.Name))
    {
        textBox.Text = "No name!";
    }
    else
    {
        textBox.Text = textBox.Name;
    }
}
```
<a href="https://imgur.com/mSGz5xp"><img src="https://i.imgur.com/mSGz5xp.png" title="source: imgur.com" /></a>

###　採用x:Name方式

```
<StackPanel>
    <TextBox x:Name Margin="5"/>
    <Button Content="OK" Margin="5" Click="Button_Click"/>
</StackPanel>
```

```
private void Button_Click(object sender, RoutedEventArgs e)
{
    if (string.IsNullOrEmpty(textBox.Name))
    {
        textBox.Text = "No name!";
    }
    else
    {
        textBox.Text = textBox.Name;
    }
}
```
<a href="https://imgur.com/tM9q6Dd"><img src="https://i.imgur.com/tM9q6Dd.png" title="source: imgur.com" /></a>

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