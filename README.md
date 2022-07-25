# csharp_example


## WPF

1.使用Window.Resources定義變數

下例新增human物件且設定Child值為ABS

```
<Window x:Class="WpfApp1.MainWindow"
    <Window.Resources>
        <local:Human x:Key="human" Child="ABC"/>
    </Window.Resources>
```    

```
    public class Human
    {
        public string Name { get; set; }
        public string Child { get; set; }
    }
```

2.程式使用FindResource

```
            Human h = (Human)this.FindResource("human");
            MessageBox.Show(h.Name.ToString());
```

<a href="https://imgur.com/I5RjNXx"><img src="https://i.imgur.com/I5RjNXx.png" title="source: imgur.com" /></a>

參考:  
- [程式碼隱藏的資源][1]


[1]:http://www.tastones.com/zh-tw/stackoverflow/wpf/wpf-resources/resources_from_code-behind/