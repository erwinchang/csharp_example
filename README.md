# csharp_example

## 觀察者模式(Observer Pattern)

- 說明  
Observer Pattern定義物件之間一對多的關系  
當一個物件改變狀態，其它相依者都會收到通知並且自動被更新  

- 應用  
如同報紙訂閱服務一樣  


```
User:Joe,observerState:Hello World!
User:Gino,observerState:Hello World!
User:Jack,observerState:Hello World!
```


[C# Observer][3]
<a href="https://imgur.com/MIenuQY"><img src="https://i.imgur.com/MIenuQY.png" title="source: imgur.com" width="400px" /></a>

--------

## EX02 [觀察者模式][1]

<a href="https://imgur.com/7fR7fQr"><img src="https://i.imgur.com/7fR7fQr.png" title="source: imgur.com" width="400px" /></a>

抽象目標類別  
- 此抽象類別提供一個界面讓觀察者進行添附與解附作業。此類別內有個不公開的觀察者串鍊，並透過下列函式(方法)進行作業  
- 添附(Attach)：新增觀察者到串鍊內，以追蹤目標物件的變化。  
- 解附(Detach)：將已經存在的觀察者從串鍊中移除。  
- 通知(Notify)：利用觀察者所提供的更新函式來通知此目標已經產生變化  

用途
- 當其中一個物件的變更會影響其他物件，卻又不知道多少物件必須被同時變更時
- 當物件應該有能力通知其他物件，又不應該知道其他物件的實做細節時

測試結果
```
Observer1:message 1
Observer2:message 1
Observer1:message 2
Observer2:message 2
```

--------

## EX03 

[Observer Pattern到Delegate和Event][2]  

測試結果   

```
Desktop App被通知溫度變化了: 30.5
Mobile App被通知溫度變化了: 30.5
Desktop App被通知溫度變化了: 28.6
Mobile App被通知溫度變化了: 28.6
Desktop App被通知溫度變化了: 27.2
```

以Delegate實現測試如下  

```
Delegate Demo
溫度發生變化了...30.5
Desktop App被通知溫度變化了: 30.5
Mobile App被通知溫度變化了: 30.5
溫度發生變化了...28.6
Desktop App被通知溫度變化了: 28.6
Mobile App被通知溫度變化了: 28.6
溫度發生變化了...27.2
Desktop App被通知溫度變化了: 27.2
```

TempatureChangedHandler需為delegate  
```
public delegate void TempatureChangedHandler(double tempature);
```


-------

### EX 

測試結果如下
```
Arrivals information from BaggageClaimMonitor1
Detroit                712    3

Arrivals information from BaggageClaimMonitor1
Detroit                712    3
Kalamazoo              712    3

Arrivals information from BaggageClaimMonitor1
Detroit                712    3
Kalamazoo              712    3
New York-Kennedy       400    1

Arrivals information from SecurityExit
Detroit                712    3

Arrivals information from SecurityExit
Detroit                712    3
Kalamazoo              712    3

Arrivals information from SecurityExit
Detroit                712    3
Kalamazoo              712    3
New York-Kennedy       400    1

Arrivals information from BaggageClaimMonitor1
Detroit                712    3
Kalamazoo              712    3
New York-Kennedy       400    1
San Francisco          511    2

Arrivals information from SecurityExit
Detroit                712    3
Kalamazoo              712    3
New York-Kennedy       400    1
San Francisco          511    2

Arrivals information from BaggageClaimMonitor1
New York-Kennedy       400    1
San Francisco          511    2

Arrivals information from SecurityExit
New York-Kennedy       400    1
San Francisco          511    2

Arrivals information from BaggageClaimMonitor1
San Francisco          511    2
```
[1]:https://zh.wikipedia.org/wiki/%E8%A7%82%E5%AF%9F%E8%80%85%E6%A8%A1%E5%BC%8F
[2]:https://dotblogs.com.tw/wellwind/2016/05/22/csharp-observer-pattern-delegate-event
[3]:https://www.dofactory.com/net/observer-design-pattern