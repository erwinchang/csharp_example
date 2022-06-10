# csharp_example

## drapper

好處
- 採用物件方式將資料整個讀取

說明
- 1 Dapper是.NET開發平台的ORM(Object Relationship Mapping)套件， 
     用於資料庫存取時提供物件關聯對應功能，取出資料時**將資料轉換成強型別的物件**，  
     使開發過程中更容易操作、使用，其撰寫方式與 ADO.NET 寫法相似  

- 2 Dapper不相依任何資料庫,可以在所有ADO.NET有支援的資料庫上使用,  
    包括SQLite、SQL CE、Firebird、Oracle、MySQL、PostgreSQL 和 SQL Server,對應的資料庫存取套件  
    SQL Server: System.Data.SqlClient  
    SQLite: System.Data.SQLite  



採用最原始方式(System.Data.SQLite)去讀取sqlite table如下  
需要個別欄位去讀取  

```
using (var reader = command.ExecuteReader())
{
   	while (reader.Read())
   	{
       	var CustomerID = reader.GetString(0);
       	var CompanyName = reader.GetString(1);
       	xx
   	}
}
```

改用Drapper方式，可以採用物件方式讀取如下  

```
var customers = conn.Query<Cutomer>(sql);  //Query<xx> 就是Drapper實現
foreach(var cust in customers)
{
    Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.City},{cust.Phone}");
}

xx
public class Cutomer
{
    public string CustomerID { get; set; }
    public string CompanName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
}
```

-----------------

### 範例 1-1 查詢結果為自定義的物件


- 定義物件欄位跟Table數量不一致也不會有問題   
- 注意:定義物件名稱要跟table欄位名稱一樣才會讀取的出來  

<a href="https://imgur.com/T9Occpy"><img src="https://i.imgur.com/T9Occpy.png" title="source: imgur.com" /></a>

Customers 這個 table 的所有欄位，雖然我們語法的 select 是*把全部欄位都撈出來，  
對應到 Customer 物件只有其中5個欄位，但只要欄位名稱相同，   
Dapper 就可以把對應的內容塞回 Customer 物件，欄位數量不同也不會出錯


```
string strConnection = "Data Source=db.db;";
using (SQLiteConnection conn = new SQLiteConnection(strConnection)){
	conn.Open();
	string sql = "select * from Customers";
	var customers = conn.Query<Cutomer>(sql);
	foreach (var cust in customers){
		Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.Citys},{cust.Phone}");
	}
}
```


執行結果如下，因為物件定義名稱CompanName，在Table裡是是CompanyName所以沒有讀到料資

```
ID01,,Addr01,City01,0932
ID02,,Addr02,City02,0921
```

c#取到物件資料如下
<a href "https://imgur.com/pAmRzVc"><img src="https://i.imgur.com/pAmRzVc.png" title="source: imgur.com" /></a>

### 範例 1-2 使用回傳值為 dynamic 型別的 Query 方法

```
string sql = "select * from Customers";
var customers = conn.Query(sql);
foreach (var cust in customers){
	 Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.Citys},{cust.Phone}");
}
```

輸出結果一樣

```
ID01,,Addr01,,0932
ID02,,Addr02,,0921
```

不指定物件方式，Drapper會將全部資料讀回來如下
<a href="https://imgur.com/0YqrPrT"><img src="https://i.imgur.com/0YqrPrT.png" title="source: imgur.com" /></a>


### 範例 1-3 where in查詢

table內容如下
<a href="https://imgur.com/mYorRU0"><img src="https://i.imgur.com/mYorRU0.png" title="source: imgur.com" /></a>

```
string sql = "select * from Customers where City in @Cities";
var parameters = new{
	Cities = new[] { "City01"}
	};
var customers = conn.Query(sql, parameters);
foreach (var cust in customers){
	Console.WriteLine($"{cust.CustomerID},{cust.CompanName},{cust.Address},{cust.Citys},{cust.Phone}");
}
```

```
ID01,,Addr01,,0932
ID03,,Addr03,,0911
ID04,,Addr04,,0921
```

採用查詢方式如下 
只回傳City為City01資料  

<a href="https://imgur.com/h4dv3y0"><img src="https://i.imgur.com/h4dv3y0.png" title="source: imgur.com" /></a>

-------


## 參考來源:
- [Dapper 筆記][1]
- [DapperLib/Dapper][2]
- [短小精幹的ORM-Dapper介紹][3]

[1]:https://blog.poychang.net/note-dapper/
[2]:https://github.com/DapperLib/Dapper
[3]:https://www.tpisoftware.com/tpu/articleDetails/1046