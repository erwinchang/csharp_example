# csharp_example

## 策略模式(Strategy Pattern)  

### Ex01

- 說明:   
策略模式(Strategy Pattern)定義了演算法class，個別封裝起來，讓它們之間可以互相替換，此模式讓演算法的變動，不會影響到使用演算法的程式  

- 適用情境:  
  1. 將變動部份抽離出來，用介面(合成)或抽像類別(繼承)宣告  
  2. ex.存取資料來源可能是SQL Server或HBase，此時可以宣告iDataSource來各別實做  


- 此範例
  1.依據SourceStrategy抽像類別  
  2.分別實做二種類料庫來源(SQLSource/HBaseSource)  
  3.利用動態置換技巧(setIFindString)  


### 執行結果

```
按下SQL
String finding from SQL !!, FindWithSQL

按下HBase
String finding from HBase !!, FindWithHBase

按下Dynamic
String finding from BigData !!, FindWithBigData
String finding from BigData !!, FindWithBigData
```

----------

## EX02 [Strategy in C#][1]

- 1.定義IStrategy介面  
- 2.建立兩種Strategy(ConcreteStrategyA/ConcreteStrategyB)  
- 3.應用Context class內部private IStrategy _strategy  
- 4.由SetStrategy動態設定  

此方式，可以用來做為實做不同power supply控制方式  


#### 說明

[Strategy][2]  

***Strategy*** is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.  

- Problem    
One day you decided to create a navigation app for casual travelers.  

- Solution  
The Strategy pattern suggests that you take a class that does something specific in a lot of different ways and extract all of these algorithms into separate classes called strategies.  


In our navigation app, each routing algorithm can be extracted to its own class with a single ```buildRoute``` method.  
The method accepts an origin and destination and returns a collection of the route’s checkpoints  

<a href="https://imgur.com/qm3K2GC"><img src="https://i.imgur.com/qm3K2GC.png" title="source: imgur.com" width="400px" /></a>

<a href="https://imgur.com/SEQY7dZ"><img src="https://i.imgur.com/SEQY7dZ.png" title="source: imgur.com" width="400px" /></a>


- ***Applicability***  
Use the Strategy pattern when you want to use different variants of an algorithm within an object and be able to switch from one algorithm to another during runtime.



### 執行結果

```
Client: Strategy is set to normal sorting.
Context: Sorting data using the strategy (not sure how it'll do it)
a,b,c,d,e,

Client: Strategy is set to reverse sorting.
Context: Sorting data using the strategy (not sure how it'll do it)
e,d,c,b,a,
```

### 參考

- 下例說明很清楚  
 - [C#設計模式系列菜單-『Strategy Pattern][3]  
 多用合成，少用繼承  
 - [C# Strategy][4]  


[1]:https://refactoring.guru/design-patterns/strategy/csharp/example
[2]:https://refactoring.guru/design-patterns/strategy
[3]:https://dotblogs.com.tw/h091237557/2014/05/29/145301
[4]:https://www.dofactory.com/net/strategy-design-pattern