## 4-3-7 Environment環境

## 1 Controller 及 View中使用變數

### 1-1 採用ViewData

Controller/Action用ViewData傳遞給View


Controllers/ProductsController.cs
```
namespace CoreMvc3_firstMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ProductsController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            ViewData["EnvName"] = _env.EnvironmentName;
            return View();
        }
    }
```

Views/Products/Index.cshtml
```
<h1>Index123</h1>
<p>EnvName: @ViewData["EnvName"]</p>
```    

<a href="https://imgur.com/t84rnlP"><img src="https://i.imgur.com/t84rnlP.png" title="source: imgur.com" /></a>

### 1-2 採用IWebHostEnvironment

在View直接inject Hosting就不用通過ViewData

Views/Products/Index.cshtml
```
@inject Microsoft.AspNetCore.Hosting.IWebHostEnvironment env

@{
    ViewData["Title"] = "Index";
    string DisplayEnvironment(string envName) =>
        envName switch
        {
            "Development" => "開發環境111",
            "Staging" => "預備環境222",
            "Production" => "生產環境333",
            _ => "其它環境"
        };
}
<h1>Index123</h1>
<p>EnvName: @ViewData["EnvName"]</p>
<p>目前環境是: @DisplayEnvironment(env.EnvironmentName)</p>
```

### 1-3 在View中直接採用environment

```
<environment include="Development">
    <h2>Development Test </h2>
</environment>
<environment include="Staging">
    <h2>Staging Test </h2>
</environment>
```