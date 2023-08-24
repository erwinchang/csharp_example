## CH6-4-Boostrap

### 1 NuGet加入下例package

```
Microsoft.EntityFrameworkCore.SqlServer 3.1.0
Microsoft.EntityFrameworkCore.Tools 3.1.0
```

### 2 建立CRUD樣板

1. 新增Models/Employee.cs
2. Controller資料夾按滑鼠右鍵->加入->新增Scaffold項目

<img src="https://i.imgur.com/QIJ3EMu.png" title="" width="400" />

<img src="https://i.imgur.com/3XsmjQw.png" title="" width="400" />

<img src="https://i.imgur.com/9vwURkc.png" title="" width="400" />

### 3 建立DB

1. 修正appsettings.json
```
Database=Bootstrap_EmployeeDB
```

2. 新增Data/EmployeeContext.cs
建立種子資料

3. 開啟套件管理器主控台 執行
記得先在SQLServer建立Bootstrap_EmployeeDB
```
Add-Migration InitialDB
Update-Database
```
<img src="https://i.imgur.com/pVmfBh6.png" title="" width="500" />

### 4 測試如下

<img src="https://i.imgur.com/5vxomxG.png" title="" width="500" />

### 4 boostrap測試

```
<div class="jumbotron bg-success p-3">
    <h2>員工基本資料</h2>
</div>
<table class="table table-bordered table-striped">
```

<img src="https://i.imgur.com/eytLl7L.png" title="" width="500" />

### 5 如何升級bootstrap

1.先移除wwwroot/lib/boostrap
2.開啟用戶端程式庫如下
<img src="https://i.imgur.com/xuAWYmu.png" title="" width="500" />
3.選擇jsdlivr
<img src="https://i.imgur.com/fBxXFSI.png" title="" width="500" />


### 6 加入Font-Awesome

[How to Add Font Awesome to an ASP.NET Core Web Application][1]

### 7 patch bootstrap

新增IndexBootstrap.cshtml
<img src="https://i.imgur.com/ZAhDBbw.png" title="" width="500" />


### 注意

VS2019裡面SQL Seerver資料庫如下
<img src="https://i.imgur.com/yobeZUI.png" title="" width="500" />

查看資料如下
<img src="https://i.imgur.com/B5vlu46.png" title="" width="500" />

開啟vs2019的Sql資料如下
<img src="https://i.imgur.com/4m7zauG.png" title="" width="500" />


[1]:https://sigitov.de/how-to-add-font-awesome-to-an-asp-net-core-web-application-core-version-2-0-and-higher/


