# csharp_example

## 1 安裝 dotnet-ef

https://www.nuget.org/packages/dotnet-ef/3.1.32#supportedframeworks-body-tab

```
dotnet tool install --global dotnet-ef --version 3.1.32
```

## 2 安裝sql server

### 2-1 SQL Server

https://ithelp.ithome.com.tw/articles/10282651
採用windows驗證模式

<a href="https://imgur.com/YbVlcS8"><img src="https://i.imgur.com/YbVlcS8.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/iQ61L51"><img src="https://i.imgur.com/iQ61L51.png" title="source: imgur.com" /></a>

```
https://github.com/Microsoft/sql-server-samples/tree/master/samples
https://github.com/Azure/azure-sql-database-samples
```

### 2-2 SSMS

安裝SSMS(SQL Server Management)

## 3 新增 驗證 個別使用者帳號

<a href="https://imgur.com/srjskrg"><img src="https://i.imgur.com/srjskrg.png" title="source: imgur.com" /></a>

```
dotnet ef database update
```

```
PS D:\gitWork\net_web\github\csharp_example\CoreMvc3_Identity\CoreMvc3_Identity> dotnet ef database update
Build started...
Build succeeded.
Microsoft.Data.SqlClient.SqlException (0x80131904): Login failed for user 'xx\xx'.
```
