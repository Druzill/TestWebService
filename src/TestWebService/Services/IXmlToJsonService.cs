namespace TestWebService.Services
{
    /// <summary>
    /// This interface provide a method to convert an xml string to an json string
    /// </summary>
    public interface IXmlToJsonService
    {
        /// <summary>
        /// Convert an xml string to a json string
        /// </summary>
        /// <param name="xml">xml string to convert</param>
        /// <returns>return the json string</returns>
        string XmlToJson(string xml);
    }
}
