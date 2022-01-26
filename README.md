# csharp_example

[Newtonsoft.Json高级用法][1]  
Json.Net是支持序列化和反序列化DataTable,DataSet,Entity Framework和Entity的。下面分别举例说明序列化和反序列化。

用法
```
using Newtonsoft.Json;
```

1-1 JsonConvert.SerializeObject

SerializeObject(Object)	
Serializes the specified object to a JSON string. 

將datatable轉為json格式如下

```
[{"Age":1,"Name":"Name0","Sex":"男","IsMarry":false},{"Age":2,"Name":"Name1","Sex":"女","IsMarry":true},{"Age":3,"Name":"Name2","Sex":"男","IsMarry":false},{"Age":4,"Name":"Name3","Sex":"女","IsMarry":true}]
```

1-2 JsonConvert.DeserializeObject



JsonConvertDeserializeObjectT Method (String)

```
DataTable dt2 = JsonConvert.DeserializeObject<DataTable>(json);
```

解為DataTable資料內容如下
```
1	Name0	男	False
2	Name1	女	True
3	Name2	男	False
4	Name3	女	True
```

[Json.NET Documentation][2]

[1]:https://www.cnblogs.com/yanweidie/p/4605212.html
[2]:https://www.newtonsoft.com/json/help/html/N_Newtonsoft_Json.htm
