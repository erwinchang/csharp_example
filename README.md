# csharp_example


## [MeasureOverride和ArrangeOverride][1]

1. 通過MeasureOverride取得，元件大小，最後回傳整個大小  
```
        protected override Size MeasureOverride(Size availableSize)
        {
            var mySize = new Size();

            WriteLine(string.Format("[MeasureOverride] mySize:{0}", mySize.ToString()));

            int cnt = 0;
            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(availableSize);
                mySize.Width += child.DesiredSize.Width;
                mySize.Height += child.DesiredSize.Height;
                cnt++;
                WriteLine(string.Format("[MeasureOverride] [{0}] mySize:{1}, DesiredSize:{2}", cnt, mySize.ToString(), child.DesiredSize.ToString()));
            }

            WriteLine(string.Format("[MeasureOverride] mySize:{0}, cnt:{1}", mySize.ToString(),cnt.ToString()));
            return mySize;
        }
```

2. 通過ArrangeOverride來排例，元件位置  
```
        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point();
                        foreach (UIElement child in this.InternalChildren)
            {

                if (childNumber < middleChild)
                {
                    child.Arrange(new Rect(location, child.DesiredSize));
                    location.X += child.DesiredSize.Width;
                    location.Y += child.DesiredSize.Height;
```


[WPF 入门教程MeasureOverride和ArrangeOverride][1]
UIElement类提供的另外两种方法Measure()，即Arrange()方法


WPF 中的布局系统是布局容器与其子级之间的对话
1. 第 1 步（测量）：以下是测量过程中发生的步骤
- 每个元素计算所需的大小并确定它想要多大
- 这是由元素通过调用每个孩子的Measure()方法并访问每个孩子的所需大小属性来实现的
- 在这种情况下，子元素还确定其所有子元素的所需大小，然后将其自己的所需大小返回给父控件

2. 第 2 步（排列）：以下是排列过程中发生的步骤
Arrange()每个元素通过调用每个直接子元素的方法来排列其子元素

在这两个步骤之后，渲染发生并且元素出现在屏幕上


[1]:https://zhuanlan.zhihu.com/p/502902641