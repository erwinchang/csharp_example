# mvc example 1


## Ch4-2 Log

### Logging

| Log | Level |
|:----|:------|
| None| 6 |
| Critical | 5 |
| Error | 4 |
| Warning | 3|
| Information | 2 |
| Debug | 1 |
| Trace | 0 |

AddEventLog 會加到Windows事件檢視器中  

在vs2019 的console輸出會看到下例訊息  
```
CoreMvc3_firstMVC.Controllers.HomeController: Warning: Logging - LogWarning()記錄資訊- Home/Index被呼叫
CoreMvc3_firstMVC.Controllers.HomeController Warning: 1234 : Logging - LogWarning()記錄資訊- Home/Index被呼叫
```

Program.cs
```
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddEventSourceLogger();
                    loggingBuilder.AddEventLog();    #此會加到Windows事件檢視器中
                    loggingBuilder.AddTraceSource(new SourceSwitch("loggingSwitch", "Verbose"), new TextWriterTraceListener("LoggingService.txt"));
                    //loggingBuilder.AddAzureWebAppDiagnostics();
                    //loggingBuilder.AddApplicationInsights();
                });
```

HomeController.cs
```
        public IActionResult Index()
        {
            EventId eventId = new EventId(1234, "我的記錄資訊");
            _logger.LogTrace(eventId, "Logging - LogTrace()記錄資訊- Home/Index被呼叫");
            _logger.LogDebug(1234, "Logging - LogDebug()記錄資訊- Home/Index被呼叫");
            _logger.LogWarning(1234, "Logging - LogWarning()記錄資訊- Home/Index被呼叫");
            return View();
        }
```

appsettings.json / appsettings.Development.json可以更改level
預計為Information(2)，因此上面範例只會顯示Warning(3)
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```