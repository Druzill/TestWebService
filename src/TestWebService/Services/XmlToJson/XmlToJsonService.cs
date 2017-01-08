using log4net;
using TestWebService.Services.Core;
using System.Xml;
using Newtonsoft.Json;

namespace TestWebService.Services.XmlToJson
{
    /// <summary>
    /// XmlJsonService implementation
    /// </summary>
    public class XmlToJsonService : BaseService, IXmlToJsonService
    {
        #region ctor

        public XmlToJsonService(ILog logger)
            : base(logger)
        {
        }

        #endregion

        #region IXmlToJSonService Members

        string IXmlToJsonService.XmlToJson(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return BadXmlFormat;

            try
            {
                // Load the xml string in a XmlDocument
                var doc = new XmlDocument();
                doc.LoadXml(xml);

                // Convert to a json string
                return JsonConvert.SerializeXmlNode(doc);
            }
            catch(XmlException ex)
            {
                Logger.Error("Error while converting the xml : ", ex);
                return BadXmlFormat;
            }
        }

        #endregion

        #region Internals
        private const string BadXmlFormat = "Bad Xml Format";
        #endregion
    }
}