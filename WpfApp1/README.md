# csharp_example


## WPF Adorner

[WPF 装饰器（Adorner）][1]

建立class (TestAdorner.cs)
將代入元件四角畫上圓
```
    public class TestAdorner : Adorner
    {
        public TestAdorner(UIElement adornedElement) : base(adornedElement)
        {

        }
```

test
```
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {

            var layer = AdornerLayer.GetAdornerLayer(myButton);
            layer.Add(new TestAdorner(myButton));
        }
```

### 其它說明

#### [C# wpf利用附加属性实现界面上定义装饰器][2]

- Adorner是WPF中可以浮在控件上面的一種組件


#### [AdornerLayer Class][3]

```
Inheritance
Object
DispatcherObject
DependencyObject
Visual
UIElement
FrameworkElement
AdornerLayer
```

```
public class AdornerLayer : System.Windows.FrameworkElement
```
An adorner layer is guaranteed to be at a higher Z-order than the element(s) being adorned, so adorners are always rendered on top of the adorned element.

#### [AdornerLayer.GetAdornerLayer][4]

Returns the first adorner layer in the visual tree above a specified Visual.

[1]:https://blog.csdn.net/qq_43024228/article/details/110454081
[2]:https://www.jb51.net/article/270248.htm
[3]:https://learn.microsoft.com/en-us/dotnet/api/system.windows.documents.adornerlayer?view=windowsdesktop-7.0
[4]:https://learn.microsoft.com/en-us/dotnet/api/system.windows.documents.adornerlayer.getadornerlayer?redirectedfrom=MSDN&view=windowsdesktop-7.0#System_Windows_Documents_AdornerLayer_GetAdornerLayer_System_Windows_Media_Visual_