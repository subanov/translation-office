namespace TranslationOffice.Domain.Exception;

public class StringNullException : ValidationException
{
    public StringNullException()
    {
    }

    public StringNullException(string message) : base(message)
    {
    }

    public StringNullException(string message, System.Exception innerException) : base(message, innerException)
    {
    }

    public static void ThrowIfNotMet(string value, string field)
    {
        if (value is null)
        {
            throw new StringNullException($"{field}: can not be empty.");
        }
    }
}