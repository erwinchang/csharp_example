# csharp_example


## WPF

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