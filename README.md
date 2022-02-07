# csharp_example

## 18-3 屬性與存取子

C#提供屬性配合get/set如下

```
    class PadClass
    {
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
```

用法如下
```
            PadClass bsus;
            bsus = new PadClass();
            bsus.Price = 25900;
         
            label1.Text = $"BSUS 平板電腦單價: {bsus.Price}";
```
