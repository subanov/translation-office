namespace TranslationOffice.Domain;

public interface IAsyncMaker
{
    Task<List<TE>> ToListAsync<TE>(IQueryable<TE> query, CancellationToken ct = default);
    Task<TE[]> ToArrayAsync<TE>(IQueryable<TE> query, CancellationToken ct = default);
    Task<TM> FirstAsync<TM>(IQueryable<TM> query, CancellationToken cancellationToken = default);
    Task<TM?> FirstOrDefaultAsync<TM>(IQueryable<TM?> query, CancellationToken cancellationToken = default);
    Task<int> CountAsync<TM>(IQueryable<TM> query, CancellationToken cancellationToken = default);
    Task<TM> MaxAsync<TM>(IQueryable<TM> query, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync<TM>(IQueryable<TM> query, CancellationToken cancellationToken = default);

}