# csharp_example


## WPF

### 5.4.5 DockerPanel

DockPanel內的元素會被附加DockerPanel.Dock這個屬性
DockerPanel.Dock有4個設定Left,Top,Righ及Bottom
DockPanel內的元件會向指定方向累積

```
<Grid>
    <DockPanel>
        <TextBox DockPanel.Dock="Top" Height="25" BorderBrush="Black"/>
        <TextBox DockPanel.Dock="Left" Width="150" BorderBrush="Black" />
        <TextBox BorderBrush="Black"/>
    </DockPanel>
</Grid>
```

<a href="https://imgur.com/L0X5nzA"><img src="https://i.imgur.com/L0X5nzA.png" title="source: imgur.com" /></a>







