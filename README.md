# csharp_example

## Install and Use a NuGet Package with the .NET CLI


目前還是無法使用CLI安裝package(即dotnet add package xxx)

### 1-1 開啟power shell terminal


![Imgur](https://i.imgur.com/Xqrwt6w.png)

另一個開啟terminal方式如下

![Imgur](https://i.imgur.com/kYUwBoS.png)

### 1-2 找package，查看安裝方式

https://www.nuget.org/packages/Newtonsoft.Json/

```
dotnet dev-certs https --trust
dotnet add package Newtonsoft.Json --version 12.0.3
```

![Imgur](https://i.imgur.com/2xXRKtZ.png)



### 1-3 驗證

先改用GUI安裝package方式，測試下例JsonConvert功能

```
        public Form1()
        {
            InitializeComponent();

            Mascot nugetMascot = new Mascot()
            {
                name = "NuGet Warrior",
                team = "NuGet",
                catchPhrase = "Where packages come to life!"
            };
            string json = JsonConvert.SerializeObject(nugetMascot);
            Console.WriteLine($"json:{json}");
        }
```

測試結果如下

```
json:{"name":"NuGet Warrior","team":"NuGet","catchPhrase":"Where packages come to life!"}
```

### 1-4 如何自動找到 using


![image](https://github.com/erwinchang/csharp_example/blob/NuGet_ex02_cli/gif/auto_add_using.gif)



[1]:https://docs.microsoft.com/zh-tw/shows/nuget-101/install-and-use-a-nuget-package-with-the-net-cli-3-of-5