# csharp_example


## WPF

採用Binding方式，將資料連結到Text  

```
<StackPanel Background="LightSlateGray">
    <TextBlock Text="{Binding ElementName=slider1,Path=Value,Mode=OneWay}" Margin="5"/>
    <Slider x:Name="slider1" Margin="5"/>
</StackPanel>
```

採用屬性元素方式如下  

```
<StackPanel Background="LightSlateGray">
    <TextBlock  Margin="5">
        <TextBlock.Text>
            <Binding ElementName="slider1" Path="Value" Mode="OneWay"/>
        </TextBlock.Text>
    </TextBlock>
    <Slider x:Name="slider1" Margin="5"/>
</StackPanel>
```    

<a href="https://imgur.com/9ToLi0r"><img src="https://i.imgur.com/9ToLi0r.png" title="source: imgur.com" /></a>


其它方式

1.下例兩個方式結果是一樣的
```
<TextBlock Text="{Binding Path=Value}" Margin="5"/>
```
```
<TextBlock Text="{Binding Value}" Margin="5"/>
```

2.下例兩個方式結果是一樣的
```
{StaticResource myString, ..}
```
```
{StaticResource ResourceKey=myString, ..}
```