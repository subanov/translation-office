using Microsoft.EntityFrameworkCore;
using TranslationOffice.Domain;

namespace TranslationOffice.Application.Data.Commands;

public abstract class InsertDbContextDataCommand<TM, TE> : IInsertDataCommand<TM, TE>
    where TE : class, IEntity
    where TM : IEntityMap<TE>
{
    private readonly DbSet<TE> _dbSet;

    protected InsertDbContextDataCommand(DbContext dbContext)
    {
        _dbSet = dbContext.Set<TE>();
    }

    public async Task<TE> InsertAsync(TM toMap, CancellationToken ct = default)
    {
        var entity = toMap.Map();
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
