using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestWebService.Services;
using TestWebService.Services.Fibonacci;

namespace TestWebService.test
{
    [TestClass]
    public class FibanacciServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var fakeLogger = new Mock<ILog>();
            _fibonacciService = new FibonacciService(fakeLogger.Object);
        }

        [TestMethod]
        public void TestFibonacci()
        {
            // Incorrect values must return "-1"
            const string IncorrectValuesErrorCode = "-1";
            Assert.AreEqual(IncorrectValuesErrorCode, _fibonacciService.Fibonacci(-10));
            Assert.AreEqual(IncorrectValuesErrorCode, _fibonacciService.Fibonacci(0));
            Assert.AreEqual(IncorrectValuesErrorCode, _fibonacciService.Fibonacci(101));

            // Correct values must return the fibonnaci sequence
            Assert.AreEqual("1", _fibonacciService.Fibonacci(1));
            Assert.AreEqual("8", _fibonacciService.Fibonacci(6));
            Assert.AreEqual("354224848179261915075", _fibonacciService.Fibonacci(100));
        }      

        private IFibonacciService _fibonacciService;
    }
}
