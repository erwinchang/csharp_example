## MSTests

[MSTest,NUnit 3,xUnit.net 2.0 比較][2]  
測試框架 (Test Framework)：MSTest,NUnit 3,xUnit.net 2.0 是比較常見的三套，尤其又以 MSTest,NUnit 3 較多人使用  

在網路範例NUnit只有visual studio 2015  
若是visual studio 2019還是建義用MSTest  



### 1.建立MSTests

### 2.設定相依

設定ExampleLibMSTests是相依ExampleLib  
即build ExampleLibMSTests會先build出ExampleLib.dll  

<a href="https://imgur.com/hRvWvuu"><img src="https://i.imgur.com/hRvWvuu.png" title="source: imgur.com" width="400px" /></a>

### 3.建立測試程式

```
    public class UnitTest1
    {
        private const string Expected = "654321";
        [TestMethod]
        public void TestMethod1()
        {
            Example ex1 = new Example();
            var result = ex1.Reverse("123456");
            Assert.AreEqual(Expected, result);
        }
    }
```

### 4.開始測試

<a href="https://imgur.com/Ux9j5x1"><img src="https://i.imgur.com/Ux9j5x1.png" title="source: imgur.com" width="400px"/></a>


-------

## 參考來源

- [開始使用單元測試][1]  
- [NUnit 入門教學][3]  

[1]:https://docs.microsoft.com/zh-tw/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest
[2]:https://blog.yowko.com/mstest-nunit-xunit/
[3]:https://marcus116.blogspot.com/2019/01/unittest-nunit.html