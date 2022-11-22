namespace TranslationOffice.Domain;

public interface IAddCommand<in TM, TE>
    where TE : IEntity
    where TM : IEntityMap<TE>
{
    Task<TE> AddAsync(TM toMap, CancellationToken ct = default);
}