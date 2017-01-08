using log4net;

namespace TestWebService.Services.Core
{
    /// <summary>
    /// This interface provide the basic finctionality for services
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Get the logger
        /// </summary>
        ILog Logger { get; }
    }
}
