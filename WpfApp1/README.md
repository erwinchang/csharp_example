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

### 3.採用DependencyProperty

何時會採用到DependencyProperty  
需要抓取改變時，順便設定UI..就會在UserControl裡面加入DependencyProperty，以便動態改變UI  

以SwitchBox為例子  
由Body來改變顯示的Title字串  
由Status來改變UI外觀(ON/OFF)  
```
public partial class cpSwitchBox : UserControl
{
	public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(nameof (Body), typeof (string), typeof (cpSwitchBox), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(cpSwitchBox.OnBodyChanged)));

    public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(nameof (Status), typeof (bool), typeof (cpSwitchBox), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(cpSwitchBox.OnChartEntriesChanged)));

    public string Body
    {
      get => (string) this.GetValue(cpSwitchBox.BodyProperty);
      set => this.SetValue(cpSwitchBox.BodyProperty, (object) value);
    }

    public bool Status
    {
      get => (bool) this.GetValue(cpSwitchBox.StatusProperty);
      set
      {
        this.SetValue(cpSwitchBox.StatusProperty, (object) value);
        this.bIsEnable = value;
      }
    }

    private static void OnBodyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      cpSwitchBox cpSwitchBox = (cpSwitchBox) d;
      cpSwitchBox.tbtBody.Text = cpSwitchBox.Body;
    }

    private static void OnChartEntriesChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      cpSwitchBox cpSwitchBox = (cpSwitchBox) d;
      if (cpSwitchBox.Status)
        cpSwitchBox.Enable();
      else
        cpSwitchBox.Disable();
    }

    public void Enable()
    {
      BrushConverter brushConverter = new BrushConverter();
      this.lab.Margin = new Thickness(3.0, 2.0, 2.0, 2.0);
      this.lab.Content = (object) "ON";

    public void Disable()
    {
      BrushConverter brushConverter = new BrushConverter();
      this.lab.Margin = new Thickness(37.0, 2.0, 2.0, 2.0);
      this.lab.Content = (object) "OFF";     
}
```

[1]:https://ascii-iicsa.blogspot.com/2014/08/dependencyproperty.html