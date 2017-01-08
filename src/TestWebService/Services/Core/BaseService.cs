using log4net;

namespace TestWebService.Services.Core
{
    /// <summary>
    /// Base Service implementation
    /// </summary>
    public abstract class BaseService : IBaseService
    {
        #region ctor
        public BaseService(ILog logger)
        {
            _logger = logger;
        }
        #endregion

        #region IService Members

        public ILog Logger
        {
            get { return _logger; }
        }

        #endregion

        #region Internals

        ILog _logger;

        #endregion
    }
}