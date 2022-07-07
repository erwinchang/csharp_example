# csharp_example


## WPF

###  1-1 ComboBox Example

``` 
<sys:String x:Key="ComboBoxTitle">Items:</sys:String>

<x:Array x:Key="ComboBoxItems" Type="sys:String">
    <sys:String>Item #1</sys:String>
    <sys:String>Item #2</sys:String>
    <sys:String>Item #3</sys:String>
</x:Array>

```
```
    <StackPanel Margin="10">
        <Label Content="{StaticResource ComboBoxTitle}" />
        <ComboBox ItemsSource="{StaticResource ComboBoxItems}" />
    </StackPanel>
```

<a href="https://imgur.com/jRoogM3"><img src="https://i.imgur.com/jRoogM3.png" title="source: imgur.com" width="400px" /></a>


[資源(Resources)][1]
[1]:https://wpf-tutorial.com/zh/12/wpf%E6%87%89%E7%94%A8%E7%A8%8B%E5%BC%8F/%E8%B3%87%E6%BA%90resources/