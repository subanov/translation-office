namespace TranslationOffice.Domain;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken ct = default);
}