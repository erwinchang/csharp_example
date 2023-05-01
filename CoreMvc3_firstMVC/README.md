# mvc example 1

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