namespace TranslationOffice.Domain.Exception;

/// <summary>
/// <see cref="RecurrentException"/> that indicates validation failure.
/// Maps to 400 in http.
/// </summary>
public class ValidationException : RecurrentException
{
    public ValidationException()
    {
    }

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}