# csharp_example


## WPF

總結: 資源定義有區域，也可以通過程式去取得定義的資源

###  1-1 資源resources / 區域及應用程式範圍資源

#### 1.如果你需要一個資源僅僅用在特定的控制項上

將Resources寫在 控制項裡面

```
<StackPanel Margin="10">
    <StackPanel.Resources>
        <sys:String x:Key="ComboBoxTitle">Items:</sys:String>
    </StackPanel.Resources>
    <Label Content="{StaticResource ComboBoxTitle}" />
</StackPanel>
```

#### 2.若將資源寫在App.xaml裡面，表示全部都能使用

- 在App.xaml檔案中可以容納像是視窗及任何其他種類的WPF控制項資源

```
<Application x:Class="WpfTutorialSamples.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:sys="clr-namespace:System;assembly=mscorlib"
             StartupUri="WPF application/ExtendedResourceSample.xaml">
    <Application.Resources>
        <sys:String x:Key="ComboBoxTitle">Items:</sys:String>
    </Application.Resources>
</Application>
```

#### 3.從後置程式碼存取資源

```
private void btnClickMe_Click(object sender, RoutedEventArgs e)
{
	lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
	lbResult.Items.Add(this.FindResource("strWindow").ToString());
	lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());
}
```

<a href="https://imgur.com/JlpHaZB"><img src="https://i.imgur.com/JlpHaZB.png" title="source: imgur.com" /></a>


[資源(Resources)][1]
[1]:https://wpf-tutorial.com/zh/12/wpf%E6%87%89%E7%94%A8%E7%A8%8B%E5%BC%8F/%E8%B3%87%E6%BA%90resources/