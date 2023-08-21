## CH6-4-Boostrap

### 1 NuGet加入下例package

```
Microsoft.EntityFrameworkCore.SqlServer 3.1.0
Microsoft.EntityFrameworkCore.Tools 3.1.0
```

### 2 建立CRUD樣板

1. 新增Models/Employee.cs
2. Controller資料夾按滑鼠右鍵->加入->新增Scaffold項目

<img src="https://i.imgur.com/QIJ3EMu.png" title="" />

<img src="https://i.imgur.com/3XsmjQw.png" title="" />

<img src="https://i.imgur.com/9vwURkc.png" title="" />

### 3 建立DB

1. 修正appsettings.json
```
Database=Bootstrap_EmployeeDB
```

2. 新增Data/EmployeeContext.cs
建立種子資料

3. 開啟套件管理器主控台 執行
```
Add-Migration InitialDB
Update-Database
```

<img src="https://i.imgur.com/pVmfBh6.png" title="" />


