# mvc example 1


## Ch5

### CH5-1

由於action預設是Index, 因此會執行Controller裡的Index()
```
https://localhost:44388/Home
```

Startup.cs
```
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
            });
```

HomeController.cs
```
        public IActionResult Index()
        {
            return View();
        }
```

### CH5-2 View

Views/HOME/Index.cshtml
語法採用Razor語法，即HTML + C# 

```
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>
```

HomeController.cs
預設以Index.cshtml回應, 沒寫就是以Action名稱一樣(Index)
```
        public IActionResult Index()
        {
            return View();
        }
```

改為以IndexTest.cshtml回應

```
        public IActionResult Index()
        {
            return View("IndexTest");                        #指定名稱不需指定延伸檔名
            //return View("~/Views/Home/IndexTest.cshtml");  #完整路徑和檔名，須加上.cshtml延伸檔名
            //return View("Views/Home/IndexTest.cshtml");
        }
```
