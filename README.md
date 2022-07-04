# csharp_example

## web api example

參考[認識 Api & 使用 .net Core 來建立簡單的 Web Api 服務吧][1]  
建立web api example  

- Properties/launchSettings.json
```
    "WebApplication1": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "weatherforecast",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
```
範例只有```https://localhost:5001/weatherforecast```會有反應
其```https://localhost:5001```沒有反應

- Controllers/WeatherForecastController.cs
設定路徑即control部分
```
[HttpGet]
public IEnumerable<WeatherForecast> Get()
{
    var rng = new Random();
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
    })
    .ToArray();
}
```
設定httpget是的回應


### 測試如下

用powershell測試

```
Invoke-RestMethod https://localhost:5001/weatherforecast | ConvertTo-Json
```

<a href="https://imgur.com/s38eg3r"><img src="https://i.imgur.com/s38eg3r.png" title="source: imgur.com" width="500px" /></a>


網頁驗證如下

<a href="https://imgur.com/PnJkLXY"><img src="https://i.imgur.com/PnJkLXY.png" title="source: imgur.com" /></a>

-------


## [ASP.NET Core 中的路由至控制器動作][2]


### 1-1 API 的屬性路由 REST

HomeController 會比對一組類似預設傳統路由 ```{controller=Home}/{action=Index}/{id?}``` 相符的 URL

```
public class HomeController : Controller
{
    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    [Route("Home/Index/{id?}")]
    public IActionResult Index(int? id)
    {
        return ControllerContext.MyDisplayRouteInfo(id);
    }

    [Route("Home/About")]
    [Route("Home/About/{id?}")]
    public IActionResult About(int? id)
    {
        return ControllerContext.MyDisplayRouteInfo(id);
    }
}
```

動作 HomeController.Index 會針對任何 URL 路徑 ```/``` 、 ```/Home``` 、 ```/Home/Index``` 或 ```/Home/Index/3``` 執行


### 1-2 HTTP 動詞範本

使用 Http 動詞屬性的屬性路由

```
[Route("api/[controller]")]
[ApiController]
public class Test2Controller : ControllerBase
{
    [HttpGet]   // GET /api/test2
    public IActionResult ListProducts()
    {
        return ControllerContext.MyDisplayRouteInfo();
    }

    [HttpGet("{id}")]   // GET /api/test2/xyz
    public IActionResult GetProduct(string id)
    {
       return ControllerContext.MyDisplayRouteInfo(id);
    }

    [HttpGet("int/{id:int}")] // GET /api/test2/int/3
    public IActionResult GetIntProduct(int id)
    {
        return ControllerContext.MyDisplayRouteInfo(id);
    }

    [HttpGet("int2/{id}")]  // GET /api/test2/int2/3
    public IActionResult GetInt2Product(int id)
    {
        return ControllerContext.MyDisplayRouteInfo(id);
    }
}
```
--------

## 參考來源:

- [ASP.NET Core 中的路由至控制器動作][2]
- [認識 Api & 使用 .net Core 來建立簡單的 Web Api 服務吧][1]

[1]:https://igouist.github.io/post/2021/05/newbie-2-webapi/
[2]:https://docs.microsoft.com/zh-tw/aspnet/core/mvc/controllers/routing?view=aspnetcore-6.0