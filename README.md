# csharp_example


## WPF

### 5.4.2 Grid

下例方式，不易維護
```
<Grid>
 <TextBlock Text="Select your department:" Margin="10,10,0,0" Height="25" Width="140" VerticalAlignment="Top" HorizontalAlignment="Left"/>
 <ComboBox Height="25" Width="210" VerticalAlignment="Top" Margin="0,10,10,0" HorizontalAlignment="Right"/>
 <TextBox BorderBrush="Black" Margin="10,40,10,40"/>
 <Button Content="Submit" Height="25" Width="80" VerticalAlignment="Bottom" HorizontalAlignment="Right" Margin="0,0,96,10"/>
 <Button Content="Clear" Height="25" Width="80" HorizontalAlignment="Right" VerticalAlignment="Bottom" Margin="0,0,10,10"/>
</Grid>
```

建議採用下例方式


<a href="https://imgur.com/hfWmfIv"><img src="https://i.imgur.com/hfWmfIv.png" title="source: imgur.com" /></a>

