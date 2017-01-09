using System.Numerics;
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

        string IFibonacciService.Fibonacci(int n)
        {
            // Check the input
            if (n < 1 || n > 100)
            {
                Logger.Error(string.Format("Invalid Argument : {0}", n));
                return "-1";
            }

            BigInteger a = 0;
            BigInteger b = 1;

            // In N steps compute Fibonacci sequence iteratively.
            for (var i = 0; i < n; i++)
            {
                BigInteger temp = a;
                a = b;
                b = temp + b;
            }
            return a.ToString();
        }

        #endregion      
    }
}