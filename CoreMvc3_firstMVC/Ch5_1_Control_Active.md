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
