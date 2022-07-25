# csharp_example


## WPF

採用Binding方式，將資料連結到Text  

```
<StackPanel Background="LightSlateGray">
    <TextBlock Text="{Binding ElementName=slider1,Path=Value,Mode=OneWay}" Margin="5"/>
    <Slider x:Name="slider1" Margin="5"/>
</StackPanel>
```

<a href="https://imgur.com/9ToLi0r"><img src="https://i.imgur.com/9ToLi0r.png" title="source: imgur.com" /></a>