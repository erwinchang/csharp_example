# csharp_example

## 18-2 類別與物件

建立PadClass.cs如下
```
namespace csharp_example
{
    class PadClass
    {
        private int price;
        public void setPrice(int tPrice)
        {
            price = tPrice;
        }
        public int getPrice()
        {
            return price;
        }
    }
}
```

使用方式
```
        private void Form1_Load(object sender, EventArgs e)
        {
            PadClass bsus;
            bsus = new PadClass();
            bsus.setPrice(25900);
         
            label1.Text = $"BSUS 平板電腦單價: {bsus.getPrice()}";
        }
```