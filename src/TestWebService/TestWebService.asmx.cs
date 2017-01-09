using System.Web.Script.Services;
using System.Web.Services;
using log4net;
using TestWebService.Services;
using System.Web.Services.Protocols;

namespace TestWebService
{
    [WebService(Namespace = "http://home.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {
        #region ctor
        static TestWebService()
        {
            log4net.Config.XmlConfigurator.Configure();
            _fibonnacciService = new Services.Fibonacci.FibonacciService(_logger);
            _xmlToJsonService = new Services.XmlToJson.XmlToJsonService(_logger);
        }
        #endregion
        
        #region WebService Methods

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Fibonacci(int n)
        {
            try
            {
                _logger.Debug(string.Format("Fibonacci start with argument {0} ...", n));
                var result = _fibonnacciService.Fibonacci(n);
                _logger.Debug(string.Format("Fibonacci return value {0} ...", result));

                return result;
            }
            catch(System.Exception ex)
            {
                // Should not go here ...
                _logger.Error("Unexpected error : ", ex);
                throw new SoapException("Fault occurred", SoapException.ServerFaultCode);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string XmlToJson(string xml)
        {
            try
            {
                _logger.Debug(string.Format("XmlToJson start with argument {0} ...", xml));
                var result = _xmlToJsonService.XmlToJson(xml);
                _logger.Debug(string.Format("XmlToJson return value {0} ...", result));
                return result;
            }
            catch (System.Exception ex)
            {
                // Should not go here ...
                _logger.Error("Unexpected error : ", ex);
                throw new SoapException("Fault occurred", SoapException.ServerFaultCode);
            }
        }

        #endregion

        #region Internals
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TestWebService));
        private static IFibonacciService _fibonnacciService;
        private static IXmlToJsonService _xmlToJsonService;

        #endregion
    }
}
