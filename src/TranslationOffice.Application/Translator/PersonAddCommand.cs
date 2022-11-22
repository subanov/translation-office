using TranslationOffice.Application.Data.Commands;
using TranslationOffice.Application.Data;
using TranslationOffice.Domain;

namespace TranslationOffice.Application;

public sealed class TranslatorInsertDbContextDataCommand : InsertDbContextDataCommand<Translator>, ITranslatorInsertDataCommand
{
    public TranslatorInsertDbContextDataCommand(TranslationOfficeDbContext dbContext) : base(dbContext)
    {
    }
}