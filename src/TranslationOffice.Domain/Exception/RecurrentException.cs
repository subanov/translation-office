using System.Runtime.Serialization;

namespace TranslationOffice.Domain.Exception;

/// <summary>
/// <see cref="Exception"/> that re-occurs if initial conditions are not changed.
/// </summary>
public class RecurrentException : System.Exception
{
    public RecurrentException()
    {
    }

    public RecurrentException(string message) : base(message)
    {
    }

    public RecurrentException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
