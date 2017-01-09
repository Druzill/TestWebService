namespace TestWebService.Services
{
    /// <summary>
    /// This interface provide a method to a value in the fibonacci sequence.
    /// </summary>
    public interface IFibonacciService
    {
        /// <summary>
        /// Get the fibonacci value for a given number
        /// Remark return type has been changed to a string to allow storage of the fibonacci value
        /// for number equal to 100 for example ( int, ulong are too small )
        /// I choose string because it will be easier to client to use its own big number library.
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>fibonacci value</returns>
        string Fibonacci(int n);
    }
}
