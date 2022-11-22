using TranslationOffice.Application;
using TranslationOffice.Application.Data;
using TranslationOffice.Domain;

namespace TranslationOffice.Api;

public sealed class TranslatorQuery
{
    [UseTranslationOfficeDbContext]
    public Task<List<Translator>> GetTranslators([ScopedService] TranslationOfficeDbContext dbContext,
        [Service] IAsyncMaker asyncMaker)
    {
        var repository = new TranslatorEfRepository(dbContext, asyncMaker);
        return repository.AllAsync();
    }
}