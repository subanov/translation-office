using Microsoft.EntityFrameworkCore;
using TranslationOffice.Application.Data;
using TranslationOffice.Domain;

namespace TranslationOffice.Api;

public sealed class TranslatorQuery
{
    [UseTranslationOfficeDbContext]
    public Task<List<Translator>> GetTranslators([ScopedService] TranslationOfficeDbContext dbContext) => dbContext.Translator.ToListAsync();
}