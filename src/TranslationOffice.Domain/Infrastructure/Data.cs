namespace TranslationOffice.Domain;

public interface IInsertDataCommand<in TM, TE>
    where TE : IEntity
    where TM : IEntityMap<TE>
{
    Task<TE> InsertAsync(TM toMap, CancellationToken ct = default);
}

public interface IRemoveDataCommand<in TE> where TE : IEntity
{
    void Remove(TE entity);
}

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken ct = default);
}

public interface IAddCommand<in TM, TE>
    where TE : IEntity
    where TM : IEntityMap<TE>
{
    Task<TE> AddAsync(TM toMap, CancellationToken ct = default);
}

public abstract class BaseAddCommand<TC, TM, TE> : IAddCommand<TM, TE>
    where TC : IInsertDataCommand<TM, TE>
    where TE : IEntity
    where TM : IEntityMap<TE>
{
    protected IUnitOfWork Uow { get; }
    protected TC DataCommand { get; }

    protected BaseAddCommand(IUnitOfWork uow, TC dataCommand)
    {
        Uow = uow;
        DataCommand = dataCommand;
    }

    public async Task<TE> AddAsync(TM toMap, CancellationToken ct = default)
    {
        var entity = await DataCommand.InsertAsync(toMap, ct);
        await Uow.CommitAsync(ct);
        return entity;
    }
}