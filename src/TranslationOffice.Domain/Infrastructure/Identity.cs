namespace TranslationOffice.Domain;

public abstract record Identity<TV>(TV Value)
{
}

public abstract record GuidIdentity(Guid Value) : Identity<Guid>(Value)
{
}
