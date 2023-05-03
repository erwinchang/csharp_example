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
dotnet tool install --global dotnet-ef --version 6.0.16
dotnet tool install --global dotnet-aspnet-codegenerator --version 6.0.13
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.16
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.13
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.16
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.16
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