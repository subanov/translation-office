using TranslationOffice.Domain.Exception;

namespace TranslationOffice.Domain;

public record TranslatorIdentity(Guid Value) : GuidIdentity(Value)
{
    public TranslatorIdentity() : this(Guid.NewGuid())
    {
    }
}


public class Translator : Entity<TranslatorIdentity, Guid>
{
    public string Name { get; }
    public string Surname { get; }
    public string Patronymic { get; }

    public Translator(string name, string surname, string patronymic) : base(new TranslatorIdentity())
    {
        StringNullOrWhitespaceMinLengthException.ThrowIfNotMet(name, 2, nameof(Name));
        StringNullOrWhitespaceMinLengthException.ThrowIfNotMet(surname, 2, nameof(Surname));
        StringNullException.ThrowIfNotMet(patronymic, nameof(Patronymic));

        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }
}
