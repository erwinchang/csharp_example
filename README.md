# csharp_example


## WPF

屬性元素設定方式如下
```
<ClassName>
    <ClassName.PropertyName>
    </ClassName.PropertyName>
</ClassName>
```

原本
```
<Rectangle x:Name="rectangle" Width="200" Height="120" Fill="Blue"/>
```

改成如下
```
<Rectangle x:Name="rectangle" Width="200" Height="120">
    <Rectangle.Fill>
        <SolidColorBrush Color="Blue"/>
    </Rectangle.Fill>
</Rectangle>
```

StartPoint及EndPoint是指向量連線
設定矩形的左上角為0,0為StartPoint
設定矩形的右下角為1,1為EndPoint
```
<Grid HorizontalAlignment="Center" VerticalAlignment="Center">
    <Rectangle x:Name="rectangle" Width="200" Height="120">
        <Rectangle.Fill>
            <LinearGradientBrush>
                <LinearGradientBrush.StartPoint>
                    <Point X="0" Y="0" />
                </LinearGradientBrush.StartPoint>
                <LinearGradientBrush.EndPoint>
                    <Point X="1" Y="1" />
                </LinearGradientBrush.EndPoint>
                <LinearGradientBrush.GradientStops>
                    <GradientStopCollection>
                        <GradientStop Offset="0.2" Color="LightBlue"/>
                        <GradientStop Offset="0.7" Color="Blue"/>
                        <GradientStop Offset="1.0" Color="DarkBlue"/>
                    </GradientStopCollection>
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Rectangle.Fill>
    </Rectangle>
</Grid>
```
<a href="https://imgur.com/qvTbiWF"><img src="https://i.imgur.com/qvTbiWF.png" title="source: imgur.com" /></a>