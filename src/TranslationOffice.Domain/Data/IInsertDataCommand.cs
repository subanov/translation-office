namespace TranslationOffice.Domain;

public interface IInsertDataCommand<TE> where TE : IEntity
{
    Task<TE> InsertAsync(TE entity, CancellationToken ct = default);
}
