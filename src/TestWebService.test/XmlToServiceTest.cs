using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestWebService.Services;
using TestWebService.Services.XmlToJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestWebService.test
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class XmlToServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var fakeLogger = new Mock<ILog>();
            _xmlToJsonService = new XmlToJsonService(fakeLogger.Object);
        }

        [TestMethod]
        public void TestXmlToJson()
        {
            // Incorrect values must return Bad Xml Format
            const string BadXmlFormat = "Bad Xml Format";
            Assert.AreEqual(BadXmlFormat, _xmlToJsonService.XmlToJson(null));
            Assert.AreEqual(BadXmlFormat, _xmlToJsonService.XmlToJson(""));
            Assert.AreEqual(BadXmlFormat, _xmlToJsonService.XmlToJson("<foo>hello</bar>"));

            // Correct values must return a valid json string
            var json = _xmlToJsonService.XmlToJson("<foo>bar</foo>");
            Assert.AreEqual("{\"foo\":\"bar\"}", json);

            // Check if the json string is valid
            var jObject = JObject.Parse(json);
            Assert.AreEqual("bar", jObject.Property("foo").Value);
        }

        private IXmlToJsonService _xmlToJsonService;
    }
}
