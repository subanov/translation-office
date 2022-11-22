namespace TranslationOffice.Domain;

public interface ITranslatorRepository : IRepository
{
    Task<List<Translator>> AllAsync();
}

public class TranslatorRepository : Repository, ITranslatorRepository
{
    public TranslatorRepository(
        IQueryable<Translator> translatorQuery,
        IAsyncMaker asyncMaker
    ) : base(asyncMaker)
    {
        TranslatorQuery = translatorQuery;
    }

    private IQueryable<Translator> TranslatorQuery { get; }

    public async Task<List<Translator>> AllAsync()
    {
        return await AsyncMaker.ToListAsync(TranslatorQuery);
    }
}