# csharp_example

用ObservableCollection定義變數
當變數有改變時，將會自動產生CollectionChanged

## ObservableCollection

ObservableCollection is a collection that allows code outside the collection be aware of when changes to the collection (add, move, remove) occur.

```
public ObservableCollection<string> collection;

public Handler(){
	collection = new ObservableCollection<string>();
	collection.CollectionChanged += HandleChange;
}

private void HandleChange(object sender, NotifyCollectionChangedEventArgs e){
	if (e.Action == NotifyCollectionChangedAction.Add){
		Debug.WriteLine("HandleChange: Add");
	}
}
```


測試結果如下
```
HandleChange: Add
NewItems[0]: Test-0
collection[0]: Test-0

HandleChange: Add
NewItems[0]: Test-1
collection[0]: Test-0
collection[0]: Test-1

HandleChange: Add
NewItems[0]: Test-2
collection[0]: Test-0
collection[0]: Test-1
collection[0]: Test-2

HandleChange: Reset
```

<a href="https://imgur.com/s8P8Aw0"><img src="https://i.imgur.com/s8P8Aw0.png" title="source: imgur.com" width="400px" /></a>


[What is the use of ObservableCollection in .net?][1]
[1]:https://stackoverflow.com/questions/4279185/what-is-the-use-of-observablecollection-in-net