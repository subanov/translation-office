using Microsoft.EntityFrameworkCore;
using TranslationOffice.Domain;

namespace TranslationOffice.Application.Data.Commands;

public abstract class InsertDbContextDataCommand<TE> : IInsertDataCommand<TE> where TE : class, IEntity
{
    private readonly DbSet<TE> _dbSet;

    protected InsertDbContextDataCommand(DbContext dbContext)
    {
        _dbSet = dbContext.Set<TE>();
    }

    public async Task<TE> InsertAsync(TE entity, CancellationToken ct = default)
    {
        var entry = await _dbSet.AddAsync(entity, ct);
        return entry.Entity;
    }
}

public abstract class DbContextUnitOfWork<TC> : IUnitOfWork where TC : DbContext
{
    private readonly TC _dbContext;

    protected DbContextUnitOfWork(TC dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> CommitAsync(CancellationToken ct = default)
    {
        return await _dbContext.SaveChangesAsync(ct);
    }
}

public sealed class TranslationOfficeUnitOfWork : DbContextUnitOfWork<TranslationOfficeDbContext>
{
    public TranslationOfficeUnitOfWork(TranslationOfficeDbContext dbContext) : base(dbContext)
    {
    }
}
