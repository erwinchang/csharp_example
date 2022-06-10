# csharp_example


## sqlite example


### 1-0 [先用sqlitestudio建立test.db][3]

### 1-1 [C#安裝System.Data.SQLite套件][2]  

### 1-2 測試  

[Using SQLite in a C# Application][1]  

#### 1-2-1 建立連線  

```
SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=testdb.db;Version=3;New=True;Compress=True;");
sqlite_conn.Open();

```

#### 1-2-2 建立table  
```
SQLiteCommand sqlite_cmd;
string Createsql = "CREATE TABLE SampleTable(Col1 VARCHAR(20), Col2 INT)";
sqlite_cmd = sqlite_conn.CreateCommand();
sqlite_cmd.CommandText = Createsql;
```

<a href="https://imgur.com/AzKrQu0"><img src="https://i.imgur.com/AzKrQu0.png" title="source: imgur.com" /></a>


#### 1-2-3 寫入資料  

```
SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test Text ', 1);";
sqlite_cmd.ExecuteNonQuery();
xxx

```

<a href="https://imgur.com/hRsXorn"><img src="https://i.imgur.com/hRsXorn.png" title="source: imgur.com" /></a>


#### 1-2-4 讀出資料  

```
SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
sqlite_cmd.CommandText = "SELECT * FROM SampleTable";
sqlite_datareader = sqlite_cmd.ExecuteReader();
while (sqlite_datareader.Read()){
string myreader0 = sqlite_datareader.GetString(0);
int myreader1 = sqlite_datareader.GetInt32(1);
Console.WriteLine($"{myreader0} {myreader1}");
}
```

測試結果如下  
```
Test Text 1
Test1 Text1 2
Test2 Text2 3
```


[1]:https://www.codeguru.com/dotnet/using-sqlite-in-a-c-application/
[2]:https://www.ruyut.com/2021/06/nuget-install.html
[3]:http://www.xue51.com/soft/4831.html