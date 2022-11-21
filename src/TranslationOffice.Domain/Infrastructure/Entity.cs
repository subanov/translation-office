namespace TranslationOffice.Domain;

public interface IEntity
{
}

public abstract class Entity<TI, TV> : IEntity where TI : Identity<TV>
{
    public TI Id { get; protected set; }

    protected Entity(TI id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }
}

public interface IEntityMap<out TE>
{
    TE Map();
}
