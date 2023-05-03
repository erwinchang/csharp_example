# dotnet mvc example 


### 1

1-1 產生MvcFriends
```
dotnet new mvc -o MvcFriends
```

1-2 使用vs code開啟
```
code -r MvcFriends
```

1-3 信任https開發憑證
```
dotnet dev-certs https --trust
```

1-4 build and run
```
dotnet build
dotnet run
```


1-4 install package
```
dotnet tool install --global dotnet-ef --version 3.1.32
dotnet tool install --global dotnet-aspnet-codegenerator --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.32
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.32
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.32
```

1-5 新增Data/DatabaseContext.cs
1-6 修改Startup.cs

1-7 build

使用ef core建立Migration及產生資料庫  
```
dotnet build
dotnet ef migrations add InitialDB          #產生Migration檔
dotnet ef database update                   #產生資料庫
```

1-7-1 migrations add InitialDB

[如何使用 Code First 的 Migration][1]  
將會產生MvcFriends/Migrations相關資料  


```
PS D:\gitWork\net_web\github\csharp_example\dotnet\MvcFriends> dotnet ef  migrations add InitialDB
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'
```

1-8 新增Controller控制器 & View檢梘

```
dotnet aspnet-codegenerator controller --controllerName FriendsControllers -outDir Controllers -async -namespace MvcFriends.Controllers -m Friends -dc DatabaseContext -udl
```

```
PS D:\gitWork\net_web\github\csharp_example\dotnet\MvcFriends> dotnet aspnet-codegenerator controller --controllerName FriendsControllers -outDir Controllers -async -namespace MvcFriends.Controllers -m Friends -dc DatabaseContext -udl
Building project ...
Finding the generator 'controller'...
Running the generator 'controller'...
Attempting to compile the application in memory.
Attempting to figure out the EntityFramework metadata for the model and DbContext: 'Friends'
Added Controller : '\Controllers\FriendsControllers.cs'.
Added View : \Views\FriendsControllers\Create.cshtml
Added View : \Views\FriendsControllers\Edit.cshtml
Added View : \Views\FriendsControllers\Details.cshtml
Added View : \Views\FriendsControllers\Delete.cshtml
Added View : \Views\FriendsControllers\Index.cshtml
RunTime 00:00:07.90
PS D:\gitWork\net_web\github\csharp_example\dotnet\MvcFriends> 
```

1-9 

```
dotnet ef  migrations add AddSeedData   #產生migrations檔案
dotnet ef  database update              #此時將會在Friends資料表查看到新增3筆資料
```

### 版本確認

1.目前 .net.core 6
```
dotnet tool install --global dotnet-ef --version 6.0.16
dotnet tool install --global dotnet-aspnet-codegenerator --version 6.0.13
```

https://www.nuget.org/packages/dotnet-ef/6.0.16#readme-body-tab
https://www.nuget.org/packages/dotnet-aspnet-codegenerator/6.0.13


若遇到版本問題，先移除再指定安裝版本
```
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 3.1.32
```

### 其它

dotnet aspnet-codegenerator controller 

```
dotnet aspnet-codegenerator controller --controllerName FriendsControllers -outDir Controllers -async -namespace MvcFriends.Controllers -m Friends -dc DatabaseContext -udl
```

```
PS D:\gitWork\net_web\github\csharp_example\dotnet\MvcFriends> dotnet aspnet-codegenerator controller -h                                                                      


Usage: aspnet-codegenerator [arguments] [options]

Arguments:
  generator  Name of the generator. Check available generators below.

Options:
  -p|--project             Path to .csproj file in the project.
  -n|--nuget-package-dir
  -c|--configuration       Configuration for the project (Possible values: Debug/ Release)
  -tfm|--target-framework  Target Framework to use. (Short folder name of the tfm. eg. net46)
  -b|--build-base-path
  --no-build

Selected Code Generator: controller

Generator Options:
  --controllerName|-name              : Name of the controller
  --useAsyncActions|-async            : Switch to indicate whether to generate async controller actions
  --noViews|-nv                       : Switch to indicate whether to generate CRUD views
  --restWithNoViews|-api              : Specify this switch to generate a Controller with REST style API, noViews is assumed and any view related options are ignored
  --readWriteActions|-actions         : Specify this switch to generate Controller with read/write actions when a Model class is not used
  --model|-m                          : Model class to use
  --dataContext|-dc                   : DbContext class to use
  --referenceScriptLibraries|-scripts : Switch to specify whether to reference script libraries in the generated views
  --layout|-l                         : Custom Layout page to use
  --useDefaultLayout|-udl             : Switch to specify that default layout should be used for the views
  --force|-f                          : Use this option to overwrite existing files
  --relativeFolderPath|-outDir        : Specify the relative output folder path from project where the file needs to be generated, if not specified, file will be generated in the project folder
  --controllerNamespace|-namespace    : Specify the name of the namespace to use for the generated controller
  --useSqlite|-sqlite                 : Flag to specify if DbContext should use SQLite instead of SQL Server.


RunTime 00:00:01.22
```

[1]:https://dotblogs.com.tw/yc421206/2019/11/28/ef_core_migration