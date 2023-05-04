## 4-3-7 Environment環境

## 1 Controller 及 View中使用變數
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