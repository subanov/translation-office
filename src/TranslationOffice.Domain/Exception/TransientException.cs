using System.Runtime.Serialization;

namespace TranslationOffice.Domain.Exception;
/// <summary>
/// <see cref="Exception"/> that occurs for short period of time.
/// Running code can be called repeatedly when <see cref="TransientException"/> occurs
/// </summary>
public class TransientException : System.Exception
{
    public TransientException()
    {
    }

    public TransientException(string message) : base(message)
    {
    }

    public TransientException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
