namespace _4.merfoldko.Exceptions;

/// <summary>
/// An exception that is thrown when a city's condition is set to an illegal value, such as a value outside the valid range of 0 to 100. 
/// </summary>
public class IllegalCityConditionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the IllegalCityConditionException class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public IllegalCityConditionException(string message) : base(message)
    {
    }
}
