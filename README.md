# csharp_example

## EventHandler 

使用沒有資料的事件  

```
ThresholdReached?.Invoke(this, EventArgs.Empty);
```

測試如下  

<a href="https://imgur.com/YGRA5Va"><img src="https://i.imgur.com/YGRA5Va.png" title="source: imgur.com" width="400px" /></a>

---

使用有提供資料的事件  
EventHandler<TEventArgs> 委派會與事件相關聯，而且會提供自訂事件資料物件的執行個  

```
	ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
	args.Threshold = threshold;
	args.TimeReached = DateTime.Now;

	protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
		EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
		handler(this, e);	

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
```

<a href="https://imgur.com/o25t2mt"><img src="https://i.imgur.com/o25t2mt.png" title="source: imgur.com" width="400px" /></a>

[如何：引發和使用事件][1]

[1]:https://docs.microsoft.com/zh-tw/dotnet/standard/events/how-to-raise-and-consume-events