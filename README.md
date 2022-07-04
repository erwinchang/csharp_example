# csharp_example

## List<T>.Sor方式


### 1-1 採用IComparer<T> 實作

在物件中需要定義CompareTo
```
public class Part : IComparable<Part>
{
    public string PartName { get; set; }
    public int PartId { get; set; }
    public override string ToString()
    {
        return "ID: " + PartId + "   Name: " + PartName;
    }
    public int CompareTo(Part comparePart)
    {
	    return this.PartId.CompareTo(comparePart.PartId);
    }
}
```

### 1-2 採用calling the Sort(Comparison(T) overload

使用時直接定義

```
parts.Sort(delegate (Part x, Part y)
{
	return x.PartName.CompareTo(y.PartName);
});
```


### 測試結果如下

!<a href="https://imgur.com/m9Ozdek"><img src="https://i.imgur.com/m9Ozdek.png" title="source: imgur.com" width="400px" /></a>

## 參考來源

- [List<T>.Sort 方法][1]
- [自訂的 Class 繼承自 IComparable 以便具有 Sorting 功能][2]


[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.list-1.sort?view=net-6.0
[2]:https://py3939.pixnet.net/blog/post/28315118-%5Bc%23%5D%E8%87%AA%E8%A8%82%E7%9A%84-class-%E7%B9%BC%E6%89%BF%E8%87%AA-icomparable-%E4%BB%A5%E4%BE%BF%E5%85%B7%E6%9C%89-sorti
