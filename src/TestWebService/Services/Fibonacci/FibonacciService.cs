using log4net;
using TestWebService.Services.Core;

namespace TestWebService.Services.Fibonacci
{
    /// <summary>
    /// FibonacciService implementation
    /// </summary>
    public class FibonacciService : BaseService, IFibonacciService
    {
        #region ctor

        public FibonacciService(ILog logger)
            : base(logger)
        {
        }

        #endregion

        #region IFibonacciService Members

        int IFibonacciService.Fibonacci(int n)
        {
            // Check the input
            if (n < 1 || n > 100)
            {
                Logger.Error(string.Format("Invalid Argument : {0}", n));
                return -1;
            }

            int a = 0;
            int b = 1;

            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        #endregion      
    }
}