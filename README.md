# csharp_example


## WPF

### 5.4.4 Canvas

WPF元件無Left及Top等定位點設定
可以通過Canvas.Left及Canvas.Top來定位

```
    <Canvas>
        <TextBlock Text="Name :" Canvas.Left="12" Canvas.Top="12"/>
        <TextBox Height="23" Width="200" BorderBrush="Black" Canvas.Left="66" Canvas.Top="9"/>
        <TextBlock Text="Password:" Canvas.Left="12" Canvas.Top="40.72" Height="16" Width="36"/>
        <TextBox Height="23" Width="200" BorderBrush="Black" Canvas.Left="66" Canvas.Top="38"/>
        <Button Content="Submit" Width="80" Height="22" Canvas.Left="100" Canvas.Top="67" />
        <Button Content="Clear" Width="80" Height="22" Canvas.Left="186" Canvas.Top="67"/>
    </Canvas>
```

<a href="https://imgur.com/OmPh8iL"><img src="https://i.imgur.com/OmPh8iL.png" title="source: imgur.com" /></a>








