# csharp_example


## WPF


1. 使用StackPanel建立

```
<StackPanel Background="LightBlue">
    <TextBox x:Name="textBox1" Margin="5"/>
    <TextBox x:Name="textBox2" Margin="5"/>
    <StackPanel Orientation="Horizontal">
        <TextBox x:Name="textBox3" Width="140" Margin="5"/>
        <TextBox x:Name="textBox4" Width="120"  Margin="5"/>
    </StackPanel>
    <Button x:Name="button1" Margin="5">
        <Image Source="p0009.png" Width="23" Height="23"/>
    </Button>
</StackPanel>
```

<a href="https://imgur.com/OALKHQa"><img src="https://i.imgur.com/OALKHQa.png" title="source: imgur.com" width="400px" /></a>

2.使用Grid建立

```
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="7*"/>
        <ColumnDefinition Width="3*"/>
    </Grid.ColumnDefinitions>
</Grid>
```    
<a href="https://imgur.com/vvHQ4gO"><img src="https://i.imgur.com/vvHQ4gO.png" title="source: imgur.com" width="400px" /></a>


```
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="7*"/>
            <ColumnDefinition Width="3*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="33"/>
            <RowDefinition Height="33"/>
            <RowDefinition Height="33"/>
            <RowDefinition Height="40"/>
        </Grid.RowDefinitions>
    </Grid>
```
<a href="https://imgur.com/NJdcsLp"><img src="https://i.imgur.com/NJdcsLp.png" title="source: imgur.com" /></a>

```
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="7*"/>
            <ColumnDefinition Width="3*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="33"/>
            <RowDefinition Height="33"/>
            <RowDefinition Height="33"/>
            <RowDefinition Height="40"/>
        </Grid.RowDefinitions>
        <TextBox x:Name="textBox1" Grid.Column="0" Grid.Row="0" Grid.ColumnSpan="2" Margin="5"/>
        <TextBox x:Name="textBox2" Grid.Column="0" Grid.Row="1" Grid.ColumnSpan="2" Margin="5"/>
        <TextBox x:Name="textBox3" Grid.Column="0" Grid.Row="2" Grid.ColumnSpan="1" Margin="5"/>
        <TextBox x:Name="textBox4" Grid.Column="1" Grid.Row="2" Grid.ColumnSpan="1" Margin="5"/>
        <Button x:Name="button1" Grid.Column="0" Grid.Row="3" Grid.ColumnSpan="2" Margin="5">
            <Image Source="p0009.png" Width="23" Height="23"/>
        </Button>
    </Grid>
```

<a href="https://imgur.com/ER5tdZb"><img src="https://i.imgur.com/ER5tdZb.png" title="source: imgur.com" width="400px"/></a>