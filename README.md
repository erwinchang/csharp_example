# csharp_example

## 獨立模式(Singleton Pattern)

- 模式說明:  
  獨立模式確保一個類別只會有一個實体物件，而這個實体物件保證是該類別的唯一物件  

- 適用情境:
  適用資源共享管理，如啟動一個Windows Service通常只需要一個實例(Instance) 

###　測試結果如下

  
```
1. exe static constructor
2. exe constructor
Service Run...
Service Exit...
```

###　其它說明參考  

- [sealed (C# 參考)][1]  
套用至類別時，sealed 修飾詞可防止其他類別繼承自它  
方法或屬性上使用可覆寫基底類別中虛擬方法或屬性的 sealed 修飾詞。 這可讓您允許類別衍生自您的類別，並防止它們覆寫特定虛擬方法或屬性  

- [單例模式 (Singleton Pattern) ][2]

[1]:https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/sealed
[2]:https://raychiutw.github.io/2019/%E9%9A%A8%E6%89%8B-Design-Pattern-6-%E5%96%AE%E4%BE%8B%E6%A8%A1%E5%BC%8F-Singleton-Pattern/