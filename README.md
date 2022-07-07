# csharp_example

1.說明如何建立Grid 4格
2.如何採用StackPanel 排版，加入Text及Button

## WPF ex02

XAML 只是可由 WPF 使用的編譯器所處理的 XML
檔根 <Window>

命名空間	
- xmlns 屬性會匯入整個檔案的 XML 命名空間
- xmlns:local 命名空間會 local 宣告前置詞

屬性
- x:Class : 對應至程式碼所定義的類型(MainWindow.xaml.cs)
- Title : 宣告的任何一般屬性會設定該物件的 屬性

```
<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        
    </Grid>
</Window>
```

### 1-1 將Grid將方格分割成四個數據格

```
    <Grid Margin="10">
        
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        
    </Grid>
```

### 1-2 新增Label

定義內容 Names

這兩種方式都會完成相同的動作，將標籤的內容設定為顯示文字 Names

方式一
```
<Label>Names</Label>
```

方式二
```
<Label Content="Names" />
```

### 1-3 如何將Lable定義在特定欄位

方格會定義兩個屬性，以判斷子控制項的資料列和資料行位置： Grid.Row 和 Grid.Column

```
<Label Grid.Column="1">Names</Label>
```

### 1-4 如何讓程式也能使用ListBox

提供此控制項的名稱 lstNames
名稱會指派給具有 屬性的 x:Name 控制項

```
<ListBox Grid.Row="1" x:Name="lstNames" />
```

### 測試如下

<a href="https://imgur.com/o734yeV"><img src="https://i.imgur.com/o734yeV.png" title="source: imgur.com" /></a>


### 參考來源

[使用 .NET 建立新的 WPF 應用程式][1]

[1]:https://docs.microsoft.com/zh-tw/dotnet/desktop/wpf/get-started/create-app-visual-studio?view=netdesktop-6.0