namespace TranslationOffice.Domain;

public interface IRemoveDataCommand<in TE> where TE : IEntity
{
    void Remove(TE entity);
}