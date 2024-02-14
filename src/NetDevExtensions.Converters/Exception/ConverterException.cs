namespace NetDevExtensions.Converters.Exception;

public class ConverterException : System.Exception
{
    public ConverterException(string message) : base(message)
    {
    }

    public ConverterException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}