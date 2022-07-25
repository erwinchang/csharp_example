# csharp_example


## WPF

### 5.4.2 Grid


XAML方式如下  
```
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition />
        <RowDefinition />
        <RowDefinition />
    </Grid.RowDefinitions>
</Grid>
```

程式動態加法如下  
```
public MainWindow()
{
    InitializeComponent();
    //add 4 columns
    this.gridMain.ColumnDefinitions.Add(new ColumnDefinition());
    this.gridMain.ColumnDefinitions.Add(new ColumnDefinition());
    this.gridMain.ColumnDefinitions.Add(new ColumnDefinition());
    this.gridMain.ColumnDefinitions.Add(new ColumnDefinition());

    //add 3 rows
    this.gridMain.RowDefinitions.Add(new RowDefinition());
    this.gridMain.RowDefinitions.Add(new RowDefinition());
    this.gridMain.RowDefinitions.Add(new RowDefinition());
    this.gridMain.ShowGridLines = true;
```            

<a href="https://imgur.com/LWITZtx"><img src="https://i.imgur.com/LWITZtx.png" title="source: imgur.com" /></a>

----------

若總150px  
其中兩行採用絕對值25px  
150-25-25 = 100  
剩下100分5等分,依比例分(2:1:2)為40px:20px:40px  
```
<Grid.RowDefinitions>
    <RowDefinition heigh="25"/>
    <RowDefinition heigh="25"/>
    <RowDefinition heigh="2*"/>
    <RowDefinition heigh="1*"/>
    <RowDefinition heigh="2*"/>
</Grid.RowDefinitions>
```

也可以寫成如下

```
<Grid.RowDefinitions>
    <RowDefinition heigh="25"/>
    <RowDefinition heigh="25"/>
    <RowDefinition heigh="2*"/>
    <RowDefinition heigh="*"/>
    <RowDefinition heigh="2*"/>
</Grid.RowDefinitions>
```


