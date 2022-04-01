# csharp_example

## Decorator Pattern(裝飾模式)

說明:
 Decorator Pattern是使用物件合成的方式，達到執行期動態擴充裝飾類別  
 所以為了要解後續新功能問題，最好的方法就是不要修改已經通過測式的程式碼
 (符合開發封閉原則: 對修改封閉，對擴充開放)，以降低系統可能的錯誤風險

情境:
 擴充新功能

範例
```
    public interface iComponet
    {
        void operation();
xx
   class ConcreteComponet : iComponet
    {
xx
    class ConcreteDecoratorA : Decorator
    {            
    	public override void operation()
        {
            base.operation();
            ProcessStatus = "Sucessfully";
            MessageBox.Show("Process files " + ProcessStatus, "ConcreteDecoratorA");
```

用法
```
ConcreteComponet cc = new ConcreteComponet();
ConcreteDecoratorA cda = new ConcreteDecoratorA(cc);
ConcreteDecoratorB cdb = new ConcreteDecoratorB(cc);
//也可以 ConcreteDecoratorB cdb = new ConcreteDecoratorB(cda);
//
cda.operation();
cdb.operation();
```

-----

[Decorator pattern][1]

<a href="https://imgur.com/V6qDzT2"><img src="https://i.imgur.com/V6qDzT2.png" title="source: imgur.com" width="400px" /></a>

[Decorator in C#][2]

[1]:https://en.wikipedia.org/wiki/Decorator_pattern
[2]:https://refactoring.guru/design-patterns/decorator/csharp/example  