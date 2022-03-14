# csharp_example

## 工廠模式(Factory Pattern)

- 說明  
Factory Pattern定義建立物件判面，由次類別決定實体化的類別

- 應用  
動態決定要使用物件，ex:有四個檔案格式(txt,csv,slx,xml)，依據FileProcessor可以依格式實体化


### 測試結果

```
result: Open TXT File, BtnTXT_Click
result: Open XML File, BtnXML_Click
result: Open XLS File, BtnXLS_Click
```

-------------

## EX02 [Factory Method in C#]

[Factory Method][2]

The Factory Method pattern suggests that you replace direct object construction calls (using the new operator) with calls to a special factory method.
通過FactoryMethod而非直接new


<a href="https://imgur.com/5gZEmVP"><img src="https://i.imgur.com/5gZEmVP.png" title="source: imgur.com" width="400px" /></a>

<a href="https://imgur.com/56rcP7z"><img src="https://i.imgur.com/56rcP7z.png" title="source: imgur.com" width="400px" /></a>
For example, both Truck and Ship classes should implement the Transport interface, which declares a method called deliver. 


<a href="https://imgur.com/Bt4awrs"><img src="https://i.imgur.com/Bt4awrs.png" title="source: imgur.com" width="400px" /></a>

<a href="https://imgur.com/yLjKPvg"><img src="https://i.imgur.com/yLjKPvg.png" title="source: imgur.com" width="400px" /></a>

執行結果如下
```
App: Launched with the ConcreteCreator1.
Client: I'm not aware of the creator's class,but it still works.
Creator: The same creator's code has just worked with Result of ConcreteProduct1

App: Launched with the ConcreteCreator2.
Client: I'm not aware of the creator's class,but it still works.
Creator: The same creator's code has just worked with Result of ConcreteProduct2
```


[1]:https://refactoring.guru/design-patterns/factory-method/csharp/example
[2]:https://refactoring.guru/design-patterns/factory-method