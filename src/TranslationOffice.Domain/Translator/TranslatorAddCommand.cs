namespace TranslationOffice.Domain;

public record TranslatorAddDto(string Name, string Surname, string Patronymic) : IEntityMap<Translator>
{
    public Translator Map() => new(Name, Surname, Patronymic);
}

public interface ITranslatorInsertDataCommand : IInsertDataCommand<TranslatorAddDto, Translator>
{
}

public interface ITranslatorAddCommand : IAddCommand<TranslatorAddDto, Translator>
{
}

public class TranslatorAddCommand : BaseAddCommand<ITranslatorInsertDataCommand, TranslatorAddDto, Translator>, ITranslatorAddCommand
{
    public TranslatorAddCommand(IUnitOfWork uow, ITranslatorInsertDataCommand dataCommand) : base(uow, dataCommand)
    {
    }
}