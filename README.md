# csharp_example


-[從應用程式域取出安裝資訊][3]
每個應用程式定義域的執行個體都包含這兩個屬性及 AppDomainSetup 資訊  
可以從使用 System.AppDomain 類別的應用程式定義域擷取安裝資訊  


- [AppDomain 類別][1]  
表示應用程式定義域，也就是應用程式執行的獨立環境。 此類別無法獲得繼承。  

- [AppDomain.FriendlyName 屬性][2]
取得應用程式定義域的易記名稱

## AppDomain.FriendlyName 屬性


取得應用程式定義域的易記名稱


執行結果如下
```
Application base of csharp_example.exe:              => root.FriendlyName
	D:\gitWork\github\csharp_example\bin\Debug\      => root.SetupInformation.ApplicationBase
Application base of MyDomain:
	D:\gitWork\github\csharp_example\bin\Debug\MyAppSubfolder\

Host domain: csharp_example.exe
New domain: MyDomain
Application base is: D:\gitWork\github\csharp_example\bin\Debug\MyAppSubfolder\
Relative search path is: 
Shadow copy files is set to: False	
```


[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.appdomain?view=net-6.0
[2]:https://docs.microsoft.com/zh-tw/dotnet/api/system.appdomain.friendlyname?view=net-6.0
[3]:https://docs.microsoft.com/zh-tw/dotnet/framework/app-domains/retrieve-setup-information
