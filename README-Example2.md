## sqlite

[Microsoft.Data.Sqlite.Core 套件][1]

```
SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_sqlite3());
using var connection = new SqliteConnection();
Console.WriteLine($"System SQLite version: {connection.ServerVersion}");
```

[Microsoft.Data.Sqlite 概述][2]  
Microsoft.Data.Sqlite 是用于 SQLite 的轻型 ADO.NET 提供程序  


範例來源: [C# SQLite 基礎教學 新增、修改、刪除、查詢 (CRUD) 程式範例][6]

### 1-1 建立table

SqliteConnection => 是Microsoft.Data.Sqlite.Core 套件  
這邊採用System.Data.SQLite要改為SQLiteConnection  

說明: 執行到connection.Open();時如果沒有這個檔案就會自動建立db.db檔案  

```
string _connectionString = "Data Source=db.db;";
using (var connection = new SQLiteConnection(_connectionString))
{
    connection.Open();
    var command = connection.CreateCommand();
	command.CommandText =
    	@"CREATE TABLE users (
       	id INTEGER,
       	user_name  TEXT NOT NULL UNIQUE,
       	PRIMARY KEY(id AUTOINCREMENT)
    	);";
	command.ExecuteNonQuery();
}
```
<a href="https://imgur.com/sdaVspq"><img src="https://i.imgur.com/sdaVspq.png" title="source: imgur.com" /></a>

### 1-2 寫入資料

[SQLite last_insert_rowid()][3]  
- returns the ROWID of the last row insert from the database

[SqlCommand.ExecuteScalar ][4]
- 執行查詢，並傳回查詢所傳回之結果集中第一個資料列的第一個資料行。 忽略其他資料行或資料列
- 當第一個資料行為id，就是回傳id值

```
using (var connection = new SQLiteConnection(_connectionString))
{
	connection.Open();
	var command = connection.CreateCommand();
	command.CommandText =
    	@"  INSERT INTO users (user_name)
       	 values ($userName);
    	select last_insert_rowid();";
	command.Parameters.AddWithValue("$userName", userName);
	int id = Convert.ToInt32((object)command.ExecuteScalar());
	Debug.WriteLine($"\tid = {id}, userName = {userName}");
}
```

<a href="https://imgur.com/EJdn3GA"><img src="https://i.imgur.com/EJdn3GA.png" title="source: imgur.com" /></a>

console輸出如下
```
Insert
	id = 1, userName = Jack
Insert
	id = 2, userName = Joe
```

### 1-3 查詢

注意取得資料型態要路database裡面的table一致

```
using (var connection = new SQLiteConnection(_connectionString))
{
	connection.Open();
	var command = connection.CreateCommand();
	command.CommandText = @"  select * from users";

	using (var reader = command.ExecuteReader())
	{
    	while (reader.Read())
    	{
        	var id = reader.GetInt32(0);
        	var name = reader.GetString(1);
        	Debug.WriteLine($"\tid = {id}, name = {name}");
    	}
	}
}
```

console輸出如下

```
id = 1, name = Jack
id = 2, name = Joe
```

### 1-4 更新

將id=2的name更新為Steven如下 
```
xx
Update(2, "Steven");
xx
using (var connection = new SQLiteConnection(_connectionString))
{
	connection.Open();
	var command = connection.CreateCommand();
    command.CommandText =
        @"  UPDATE users
            SET user_name= $userName
            WHERE id = $id;";
    command.Parameters.AddWithValue("$userName", userName);
    command.Parameters.AddWithValue("id", id);
    command.ExecuteNonQuery();	 
}
```

<a href="https://imgur.com/77k6w8w"><img src="https://i.imgur.com/77k6w8w.png" title="source: imgur.com" /></a>

[Parameters.AddWithValue(“@参数”,value)方法][5]
Parameters.AddWithValue方法就不用这么麻烦了，可以直接加参数名和其值，不用再设置参数的类型


[1]:https://docs.microsoft.com/zh-tw/dotnet/standard/data/sqlite/custom-versions?tabs=netcore-cli
[2]:http://www.uims.top/docs/dotnet.cn/standard/data/sqlite/index.html?tabs=netcore-cli
[3]:https://www.w3resource.com/sqlite/core-functions-last_insert_rowid.php
[4]:https://docs.microsoft.com/zh-tw/dotnet/api/system.data.sqlclient.sqlcommand.executescalar?view=dotnet-plat-ext-6.0
[5]:https://www.cnblogs.com/kdp0213/p/8532838.html
[6]:https://www.ruyut.com/2021/12/sqlite-crud.html