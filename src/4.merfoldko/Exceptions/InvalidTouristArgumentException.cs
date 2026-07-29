namespace _4.merfoldko.Exceptions;

/// <summary>
/// An exception that is thrown when an invalid argument is provided for a tourist, such as a negative number of people or an invalid type of tourist.
/// </summary>
public class InvalidTouristArgumentException : Exception
{
    /// <summary>
    /// Initializes a new instance of the InvalidTouristArgumentException class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidTouristArgumentException(string message) : base(message)
    {
    }
}
