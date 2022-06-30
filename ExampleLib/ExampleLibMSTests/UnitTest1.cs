using ExampleLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//https://docs.microsoft.com/zh-tw/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest
namespace ExampleLibMSTests
{
    [TestClass]
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
}
