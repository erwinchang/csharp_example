# mvc example 1


## depoly

[ASP.NET Core 3.1 專案至IIS][1]

### 1 安裝 dotnet-hosting-3.1.32-win.exe

https://dotnet.microsoft.com/zh-cn/download/dotnet/3.1

Windows Hosting Bundle  => dotnet-hosting-3.1.32-win.exe


### 2 新增 web

<a href="https://imgur.com/6Yunqqj"><img src="https://i.imgur.com/6Yunqqj.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/pH3lUU6"><img src="https://i.imgur.com/pH3lUU6.png" title="source: imgur.com" /></a>

### 3 將vs2019產生的(asp.net mvc)發布


<a href="https://imgur.com/4Udweul"><img src="https://i.imgur.com/4Udweul.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/BypPpIh"><img src="https://i.imgur.com/BypPpIh.png" title="source: imgur.com" /></a>


-------------------

## 2-8 LibMan

採用libman.json管理安裝package
```
{
  "version": "1.0",
  "defaultProvider": "unpkg",
  "libraries": [
    {
      "library": "bootstrap@4.4.1",
      "destination": "wwwroot/lib/bootstrap/"
    }
  ]
}
```

### 2-8-1 安裝bootstrap

<a href="https://imgur.com/H7GqhdF"><img src="https://i.imgur.com/H7GqhdF.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/5ylVuXY"><img src="https://i.imgur.com/5ylVuXY.png" title="source: imgur.com" /></a>

----------------------------

## 1 如何加到Products

1. Controllers點右鍵，選加入，控制器

<a href="https://imgur.com/3VxfwuM"><img src="https://i.imgur.com/3VxfwuM.png" title="source: imgur.com" /></a>

新增
```
@{
    ViewData["Title"] = "Index";
}
<h1>Index</h1>
```

## 2 如何更改index方式

1. 俢改Startup.cs 

```
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
            });
```

2. 設定

<a href="https://imgur.com/sx6Y8kv"><img src="https://i.imgur.com/sx6Y8kv.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/JyETFtX"><img src="https://i.imgur.com/JyETFtX.png" title="source: imgur.com" /></a>

### 3  新增Controller

<a href="https://imgur.com/MYrQhW0"><img src="https://i.imgur.com/MYrQhW0.png" title="source: imgur.com" /></a>


[1]:https://nina-weng.medium.com/%E9%BC%A0%E5%B9%B4%E5%85%A8%E9%A6%AC%E9%90%B5%E4%BA%BA%E6%8C%91%E6%88%B0-week02-%E9%83%A8%E7%BD%B2asp-net-core-3-1-%E5%B0%88%E6%A1%88%E8%87%B3iis%E4%B8%8A-c9966f6eaf59