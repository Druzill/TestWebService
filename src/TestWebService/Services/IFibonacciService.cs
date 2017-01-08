namespace TestWebService.Services
{
    /// <summary>
    /// This interface provide a method to a value in the fibonacci sequence.
    /// </summary>
    public interface IFibonacciService
    {
        /// <summary>
        /// Get the fibonacci value for a given number
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>fibonacci value</returns>
        int Fibonacci(int n);
    }
}
