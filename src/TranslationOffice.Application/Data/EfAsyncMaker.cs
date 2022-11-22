using Microsoft.EntityFrameworkCore;
using TranslationOffice.Domain;

namespace TranslationOffice.Application.Data;

public sealed class EfAsyncMaker : IAsyncMaker
{
    public async Task<List<TE>> ToListAsync<TE>(IQueryable<TE> query, CancellationToken ct = default) => await query.ToListAsync(ct);
    public async Task<TE[]> ToArrayAsync<TE>(IQueryable<TE> query, CancellationToken ct = default) => await query.ToArrayAsync(ct);
    public async Task<TM> FirstAsync<TM>(IQueryable<TM> query, CancellationToken ct = default) => await query.FirstAsync(ct);
    public async Task<TM?> FirstOrDefaultAsync<TM>(IQueryable<TM?> query, CancellationToken ct = default) => await query.FirstOrDefaultAsync(ct);
    public async Task<int> CountAsync<TM>(IQueryable<TM> query, CancellationToken ct = default) => await query.CountAsync(ct);
    public async Task<TM> MaxAsync<TM>(IQueryable<TM> query, CancellationToken ct = default) => await query.MaxAsync(ct);
    public async Task<bool> AnyAsync<TM>(IQueryable<TM> query, CancellationToken ct = default) => await query.AnyAsync(ct);
}