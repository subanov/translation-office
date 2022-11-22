using TranslationOffice.Application.Data.Commands;
using TranslationOffice.Application.Data;
using TranslationOffice.Domain;

namespace TranslationOffice.Application;

public sealed class TranslatorEfInsertDataCommand : EfInsertDataCommand<Translator>, ITranslatorInsertDataCommand
{
    public TranslatorEfInsertDataCommand(TranslationOfficeDbContext dbContext) : base(dbContext)
    {
    }
}