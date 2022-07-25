# csharp_example


## WPF

### 5.4.2 Grid

建議採用下例方式

```
<Window x:Class="WpfApp1.MainWindow"
 Title="message board" Height="240" Width="400" MinHeight="200" MinWidth="340" MaxHeight="400" MaxWidth="600">
    <Grid Margin="10">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" MinWidth="120"/>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="80" />
            <ColumnDefinition Width="4" />
            <ColumnDefinition Width="80" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="25"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="4"/>
            <RowDefinition Height="25"/>
        </Grid.RowDefinitions>

        <TextBlock Text="Select your department:" Grid.Column="0" Grid.Row="0" VerticalAlignment="Center"/>
        <ComboBox Grid.Column="1" Grid.Row="0" Grid.ColumnSpan="4"/>
        <TextBox Grid.Column="0" Grid.Row="2" Grid.ColumnSpan="5" BorderBrush="Black"/>
        <Button Content="Submit" Grid.Column="2" Grid.Row="4"/>
        <Button Content="Clear" Grid.Column="4" Grid.Row="4"/>
    </Grid> 
```

<a href="https://imgur.com/goYp0WD"><img src="https://i.imgur.com/goYp0WD.png" title="source: imgur.com" /></a>


```
<Grid Margin="10">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" MinWidth="120"/>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="80" />
        <ColumnDefinition Width="4" />
        <ColumnDefinition Width="80" />
    </Grid.ColumnDefinitions>
</Grid>
```
<a href="https://imgur.com/q6JvEZO"><img src="https://i.imgur.com/q6JvEZO.png" title="source: imgur.com" /></a>


```
<Grid Margin="10">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" MinWidth="120"/>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="80" />
        <ColumnDefinition Width="4" />
        <ColumnDefinition Width="80" />
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="25"/>
        <RowDefinition Height="4"/>
        <RowDefinition Height="*"/>
        <RowDefinition Height="4"/>
        <RowDefinition Height="25"/>
    </Grid.RowDefinitions>
</Grid>
```

<a href="https://imgur.com/ivZnN7e"><img src="https://i.imgur.com/ivZnN7e.png" title="source: imgur.com" /></a>

---------


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
<a href="https://imgur.com/hfWmfIv"><img src="https://i.imgur.com/hfWmfIv.png" title="source: imgur.com" /></a>









