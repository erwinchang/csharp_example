# mvc example 1

如何加到Products

1. Controllers點右鍵，選加入，控制器

<a href="https://imgur.com/3VxfwuM"><img src="https://i.imgur.com/3VxfwuM.png" title="source: imgur.com" /></a>

新增
```
@{
    ViewData["Title"] = "Index";
}
<h1>Index</h1>
```


2. 俢改Startup.cs

```
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
            });
```