# csharp_example


## WPF DependencyProperty

### 1.使用 INotifyPropertyChanged 來建立Binding data

```
gridMain.DataContext = BindingData.vm;
```

### 2. 直接由MyUserControl設定相關變數連結

```
public partial class MyUserControl : UserControl, INotifyPropertyChanged
```


[1]:https://ascii-iicsa.blogspot.com/2014/08/dependencyproperty.html