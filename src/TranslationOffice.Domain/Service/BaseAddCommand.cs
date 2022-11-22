namespace TranslationOffice.Domain;

public abstract class BaseAddCommand<TC, TM, TE> : IAddCommand<TM, TE>
    where TC : IInsertDataCommand<TE>
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
        var entity = toMap.Map();
        var insertedEntity = await DataCommand.InsertAsync(entity, ct);
        await Uow.CommitAsync(ct);
        return insertedEntity;
    }
}