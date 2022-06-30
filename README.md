## MSTests

1.建立MSTests

2.設定相依
設定ExampleLibMSTests是相依ExampleLib
即build ExampleLibMSTests會先build出ExampleLib.dll

<a href="https://imgur.com/hRvWvuu"><img src="https://i.imgur.com/hRvWvuu.png" title="source: imgur.com" width="400px" /></a>

3.建立測試程式

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

4.開始測試

<a href="https://imgur.com/Ux9j5x1"><img src="https://i.imgur.com/Ux9j5x1.png" title="source: imgur.com" width="400px"/></a>


-------

參考來源
- [開始使用單元測試][1]

[1]:https://docs.microsoft.com/zh-tw/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest