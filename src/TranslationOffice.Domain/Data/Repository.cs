namespace TranslationOffice.Domain;

public interface IRepository { }

public abstract class Repository : IRepository
{
    protected Repository(IAsyncMaker asyncMaker)
    {
        AsyncMaker = asyncMaker;
    }

    protected IAsyncMaker AsyncMaker { get; }
}