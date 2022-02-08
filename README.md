# csharp_example


## [Install and Use a NuGet Package with Visual Studio][1]


### 如何使用NuGet

### 1-1 安裝package

![Imgur](https://i.imgur.com/TMhVVrK.png)

### 1-2 了解如何使用工具(Humanizer)

![Imgur](https://i.imgur.com/MpkfwOH.png)


https://github.com/Humanizr/Humanizer#humanize-timespan

Humanizer meets all your .NET needs for manipulating and displaying strings, enums, dates, times, timespans, numbers and quantities.

```
// the same TimeSpan value with different precision returns different results
TimeSpan.FromMilliseconds(1299630020).Humanize() => "2 weeks"
TimeSpan.FromMilliseconds(1299630020).Humanize(3) => "2 weeks, 1 day, 1 hour"
TimeSpan.FromMilliseconds(1299630020).Humanize(4) => "2 weeks, 1 day, 1 hour, 30 seconds"
TimeSpan.FromMilliseconds(1299630020).Humanize(5) => "2 weeks, 1 day, 1 hour, 30 seconds, 20 milliseconds"
```

### 1-3 參考程式

```
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(TimeSpan.FromMilliseconds(1299630020));
            Console.WriteLine(TimeSpan.FromMilliseconds(3603001));
            Console.WriteLine(TimeSpan.FromMilliseconds(8157019263));
            Console.WriteLine(TimeSpan.FromMilliseconds(1299630020).Humanize(3));
            Console.WriteLine(TimeSpan.FromMilliseconds(3603001).Humanize(3));
            Console.WriteLine(TimeSpan.FromMilliseconds(8157019263).Humanize(3));
        }
```

測試結果如下

```
15.01:00:30.0200000
01:00:03.0010000
94.09:50:19.2630000
csharp_example.exe' (CLR v4.0.30319: csharp_example.exe): 已載入 'D:\gitWork\github\csharp_example\bin\Debug\zh-Hant\Humanizer.resources.dll'。建置的模組沒有符號。
2 周, 1 天, 1 小時
1 小時, 3 秒, 1 毫秒
13 周, 2 天, 9 小時
```



[This series is an introduction to NuGet][2]

[1]:https://docs.microsoft.com/zh-tw/shows/nuget-101/install-and-use-a-nuget-package-with-visual-studio-2-of-5
[2]:https://docs.microsoft.com/zh-tw/shows/NuGet-101/?&WT.mc_id=EducationalNuget-c9-niner