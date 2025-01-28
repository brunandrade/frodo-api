namespace Core.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task<bool> Commit(CancellationToken cancellationToken);
}
