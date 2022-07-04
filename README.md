# csharp_example

結論
- 說明net web api啟動順序
- 1. program.cs
- 2. Startup.cs

CreateHostBuilder(args).Build().Run()
- CreateHostBuilder(args) : 產生host
- Build() : Startup.cs/ ConfigureServices , Startup.cs/Configure
- Run()


## 1-1 program.cs

```
public static void Main(string[] args)
{
    CreateHostBuilder(args).Build().Run();
}

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
       .ConfigureWebHostDefaults(webBuilder =>
      {
           webBuilder.UseStartup<Startup>();
       });
```

- Program.Main 透過 BuildWebHost 方法取得 WebHost 後，再啟動 WebHos
- WebHost 就是 ASP.NET Core 的網站實體
- Run : 啟動 WebHost

## 1-2 Startup.cs

- 當網站啟動後，WebHost 會實例化 UseStartup 設定的 Startup 類別，並且呼叫以下兩個方法
- ConfigureServices
- Configure
 - IApplicationBuilder 是最重要的參數也是必要的參數，Request 進出的 Pipeline 都是透過 ApplicationBuilder 來設定

```
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
}

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

測試如下
```
public static void Main(string[] args)
{
    Output("[Program] Start");

    Output("[Program] Create HostBuilder");
    var hostBuilder = CreateHostBuilder(args);

    Output("[Program] Build Host");
    var host = hostBuilder.Build();

    Output("[Program] Run Host");
    host.Run();

    Output("[Program] End");
}

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
	    .ConfigureServices(services => {
    	    Output("[Program] hostBuilder.ConfigureServices - Called");
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
            .ConfigureServices(services =>{
                Output("[Program] webBuilder.ConfigureServices - Called");
            })
            .Configure(app => {
                Output("[Program] webBuilder.Configure - Called");
            })
            .UseStartup<Startup>();
        }
);        
```

<a href="https://imgur.com/qoFysEK"><img src="https://i.imgur.com/qoFysEK.png" title="source: imgur.com" width="500px" /></a>

## 參考來源

- [程式生命週期 (Application Lifetime)][1] 

[1]:https://blog.johnwu.cc/article/ironman-day02-asp-net-core-application-lifetime.html