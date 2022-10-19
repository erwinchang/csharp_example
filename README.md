# csharp_example


## WPF

### 說明 MVVM

[MVVM – Introduction][1]  
MVVM (Model-View-ViewModel)  

Model與View很好理解，分別對應程式中的邏輯模型與介面  
在WPF中，就分別對應了C#與XAML代碼  
- C# 就是 Model
- XAML 就是 View
- ViewModel則是連接Model與View的橋樑，幫助View取得Model中的資料  
 就是指有INotifyPropertyChanged介面，它會通知View有資料變更  

### 實作

1.建立Mode物件(即Post.cs)  

2.建立ViewMode物件(即PostsViewModel.cs)  

3.實体化VieMode物件並且與View串接(採用DataContext)  
```
 private static PostsViewModel vm = new PostsViewModel();

public MainWindow(){
    ...
    DataContext = vm;
}
```

4.建立Button變更mode範例  
```
private void ButtonChang_Click(){
 vm.PostsTitle = "Change TXT";    
}
```

### 其它說明

[WPF：建立 DataContext 的幾種寫法][5]  

1. 採用Binding Source方如下  
這種寫法有個缺點：如果有多個目標要繫結至同一個資料來源，就會寫一堆重複的程式碼，既不好看，也不利維護  
```
    <Window.Resources>
        <c:String x:Key="str1">Hello</c:String>
    </Window.Resources>
    <Grid>
        <StackPanel>
            <TextBox Text="{Binding Source={StaticResource str1}, Mode=OneWay}" />
```

2. 採用DataContext  
DataContext 意味著「資料環境」，它有那麼一點點全域變數的味道，但只限於 UI 階層的共用－－父層元素的 DataContext 可由子元素繼承並使用之  

```
  private static PostsViewModel vm = new PostsViewModel();
  public MainWindow()
  {
    InitializeComponent();
    DataContext = vm;
```

```
  <Grid>
    <Label Content="{Binding PostsTitle}"
```        

### 參考

[WPF – MVVM (一)][2]  
[WPF – MVVM (二)][3]  
[WPF – MVVM (三)][4]  

[1]:https://yuchungchuang.wordpress.com/2019/06/16/wpf-mvvm-introduction/
[2]:https://skychang.github.io/2011/12/29/WPF-%E2%80%93-MVVM-%E4%B8%80/
[3]:https://skychang.github.io/2011/12/29/WPF-%E2%80%93-MVVM-%E4%BA%8C/
[4]:https://skychang.github.io/2011/12/31/WPF-%E2%80%93-MVVM-%E4%B8%89/
[5]:

