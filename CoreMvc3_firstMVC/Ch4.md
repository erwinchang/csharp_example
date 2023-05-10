# mvc example 1


## Ch4

4-1 如何更改wwwroot目錄
4-2 如何加入靜態檔目錄
    即:設定一個目錄可以跟wwwroot共同服務

### 4-1 Web Root根目錄

1.預設wwwroot
- 此目錄存放images, css, js等

2.修改方式如下 
webBuilder.UseWebRoot  
Programe.cs  
```
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseWebRoot(Directory.GetCurrentDirectory() + "/publicshare/");
                });
```
[Day 8 Static File 靜態檔案][1]


### 4-2 用middware加入靜態檔目錄


若在StaticFileLibarary目錄加入t1.jpg如下
D:\gitWork\net_web\github\csharp_example\CoreMvc3_firstMVC\CoreMvc3_firstMVC\StaticFilesLibrary\images\t1.jpg
此時可以由url採到t1.jpg
```
https://localhost:44388/images/t1.jpg
```

```
            app.UseStaticFiles(new StaticFileOptions
            {
                 FileProvider = new
                 PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFilesLibrary"))
            });
```

若加入設定RequestPath
```
            app.UseStaticFiles(new StaticFileOptions
            {
                 FileProvider = new
                 PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFilesLibrary")),
                 RequestPath = "/StaticFiles"
            });
```
抓取方式，改為下例
```
https://localhost:44388/StaticFiles/images/t3.jpg
```

[1]:https://ithelp.ithome.com.tw/articles/10241554