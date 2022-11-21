namespace TranslationOffice.Domain.Exception;

public class StringNullOrWhitespaceMinLengthException : ValidationException
{
    public StringNullOrWhitespaceMinLengthException()
    {
    }

    public StringNullOrWhitespaceMinLengthException(string message) : base(message)
    {
    }

    public StringNullOrWhitespaceMinLengthException(string message, System.Exception innerException) : base(message, innerException)
    {
    }

    public static void ThrowIfNotMet(string value, ushort minLength, string field)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new StringNullOrWhitespaceMinLengthException($"{field}: can not be empty.");
        }

        if (value.Length < minLength)
        {
            throw new StringNullOrWhitespaceMinLengthException($"{field}: should have minimum length of: {minLength}.");
        }
    }
}