# csharp_example


## WPF

5.3.3 ItemControl類

### 1.ContentControl

都為控件(Control)　　
內容屬性的名稱為Content　　
只能由單一元系充當內容　　

- Button
- CheckBox
- ComboBoxItem


### 2.HeaderContentControl

顯示帶標題的數據  
內容屬性的名稱為Conten和Header  

GroupBox範例如下　　
```
<Grid>
    <GroupBox Margin="10" BorderBrush="Gray">
        <GroupBox.Header>
            <Image Source="p0009.png" Width="30" Height="30"/>
        </GroupBox.Header>
        <TextBlock TextWrapping="WrapWithOverflow" Text="TextBlock Wrapping" Margin="10"/>
    </GroupBox>
</Grid>
``` 

<a href="https://imgur.com/e7jKFYB"><img src="https://i.imgur.com/e7jKFYB.png" title="source: imgur.com" /></a>


### 3.ItemControl類

內容屬性的名稱為Item或ItemSource
Menu  
ContextMenu  
ComboBox
ListBox  
ListView  
TabControl    
TreeView   
Selector  
StatuBar  

```
<Grid>
    <ListBox Margin="5">
        <CheckBox x:Name="checkBoxTim" Content="Tim"/>
        <CheckBox x:Name="checkBoxTom" Content="Tom"/>
        <CheckBox x:Name="checkBoxBruce" Content="Burce"/>
        <Button x:Name="buttonMess" Content="Mess" />
        <Button x:Name="buttonOwen" Content="Owen" />
        <Button x:Name="buttonVictor" Content="Victor" />
    </ListBox>
</Grid>
```

<a href="https://imgur.com/FhtTwQv"><img src="https://i.imgur.com/FhtTwQv.png" title="source: imgur.com" /></a>


button的父級容器為ListBoxItem
```
private void buttonVictor_Click(object sender, RoutedEventArgs e)
{
    Button btn = sender as Button;
    DependencyObject leve1 = VisualTreeHelper.GetParent(btn);
    DependencyObject leve2 = VisualTreeHelper.GetParent(leve1);
    DependencyObject leve3 = VisualTreeHelper.GetParent(leve2);
    MessageBox.Show(leve3.GetType().ToString());
}
```
<a href="https://imgur.com/f5I1sck"><img src="https://i.imgur.com/f5I1sck.png" title="source: imgur.com" /></a>