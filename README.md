# csharp_example


## WPF

### 1-1 如何建立變數strHelloWorld

各個資源將透過```x:Key```屬性給予一個鍵值
靜態資源(StaticResource)僅會在XAML載入的時間點被設定一次
DynamicResource會在它實際需要時設定一次，並且當資源改變時再次設定


MainWindow.xaml

1. 定義名稱sys
```
<Window
...
xmlns:sys="clr-namespace:System;assembly=mscorlib"
>
```

2.建立變數strHelloWorld
```
<Window.Resources>
	<sys:String x:Key="strHelloWorld">Hello, world!</sys:String>
</Window.Resources>
```

3.使用變數
```
<TextBlock>Just another "<TextBlock Text="{StaticResource strHelloWorld}" />" example, but with resources!</TextBlock>
```


[資源(Resources)][1]
[1]:https://wpf-tutorial.com/zh/12/wpf%E6%87%89%E7%94%A8%E7%A8%8B%E5%BC%8F/%E8%B3%87%E6%BA%90resources/