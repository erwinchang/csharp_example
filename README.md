# csharp_example


## WPF

5.3

### 1.ContentControl

都為控件(Control)　　
內容屬性的名稱為Content　　
只能由單一元系充當內容　　

- Button
- CheckBox
- ComboBoxItem


###2.HeaderContentControl

顯示帶標題的數據　　
內容屬性的名稱為Conten和Header　　
- GroupBox　　


範例如下　　
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