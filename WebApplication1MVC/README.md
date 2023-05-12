# csharp_example

## CH5-6

### 1. 加入Friend.cs

### 2. 由Scaffolding建立FriendsController.cs (它會將View部分及Data/FriendContext部分一起建立)

<a href="https://imgur.com/gZ4Y9Ht"><img src="https://i.imgur.com/gZ4Y9Ht.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/VwPxSr6"><img src="https://i.imgur.com/VwPxSr6.png" title="source: imgur.com" /></a>

### 3.NUGet主控台

```
PM> Add-Migration InitialDB #建立Migrations及程式
Build started...
Build succeeded.
To undo this action, use Remove-Migration.

PM> Update-Database #執行程式，會產生FriendDB1資料庫
Build started...
Build succeeded.
Done.
PM> 
```

<a href="https://imgur.com/HayIZaW"><img src="https://i.imgur.com/HayIZaW.png" title="source: imgur.com" /></a>

### 4.測試

```
https://localhost:44392/Friends
```

<a href="https://imgur.com/pkwg9ro"><img src="https://i.imgur.com/pkwg9ro.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/Wus8zbS"><img src="https://i.imgur.com/Wus8zbS.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/zIgYm5Z"><img src="https://i.imgur.com/zIgYm5Z.png" title="source: imgur.com" /></a>