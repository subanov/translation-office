using TranslationOffice.Application.Data;
using TranslationOffice.Domain;

namespace TranslationOffice.Application
{
    public class TranslatorEfRepository : TranslatorRepository
    {
        public TranslatorEfRepository(TranslationOfficeDbContext dbContext, IAsyncMaker asyncMaker) : base(dbContext.Translator, asyncMaker) { }
    }
}
