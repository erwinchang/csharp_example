# mvc example 1


## Ch5

### CH5-3-4 TempData

ViewData, ViewBag 和Model 三種傳遞資料方式，適用於同一個Controller/Action資料傳送
但若不同Controll不同Action則需採用TempData

```
https://localhost:44365/PassData/PassTempData ->
https://localhost:44365/ErrorHandler/ErroraMessage
```

PassDataController.cs
```
        public IActionResult PassTempData()
        {
            TempData["ErrorMessage"] = "無足夠權限存取系統資料, 請連絡系統管理人員";
            TempData["UserName"] = "David";
            TempData["Time"] = DateTime.Now.ToLongTimeString();

            TempData["Message"] = "禁止存取";

            return RedirectToAction("ErrorMessage", "ErrorHandler");
        }
```

ErrorHandlerController.cs
```
        public IActionResult ErrorMessage()
        {
            if (!TempData.ContainsKey("ErrorMessage"))
            {
                return new EmptyResult();
            }

            //TempData.Keep();  //保留全部Key
            TempData.Keep("ErrorMessage");    //保留指定Key,若重新更新ErrorMessage.cshtml，只有ErrorMessage被保留(即儲存在Session中)

            return View();
        }
```

ErrorMessage.cshtml
```

@{
    ViewData["Title"] = "ErrorMessage";
}

<h1>ErrorMessage</h1>
<div class="jumbotron bg-info">
    <h2>以TempData跨Controller/Actions傳遞資料</h2>
</div>

<h2>訊息摘要 : </h2>
<ul>
    <li>使用者 : @TempData["UserName"]</li>
    <li>時  間 : @TempData["Time"]</li>
    <li>訊  息 : @TempData["ErrorMessage"]</li>
    <li>訊  息 : @TempData.Peek("Message")</li>
</ul>
```

### TempData Provider採用Cookie方式，如何更改採用Seesion

Startup.cs
```
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddControllersWithViews().AddSessionStateTempDataProvider();
            //services.AddSession();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthorization();
            
            //TempData Provider Cookie -> Session
            //app.UseSession();            
```