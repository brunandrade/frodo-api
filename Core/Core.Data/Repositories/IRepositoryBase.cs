using Core.Data.UnitOfWork;
using Core.Domain.DomainObjects;

namespace Core.Data.Repositories;

public interface IRepositoryBase
{
    IUnitOfWork IUnitOfWork { get; }
    Task AddAsync<T>(T entity, CancellationToken cancellationToken);
    void Update<T>(T entity);
    Task<T?> GetByIdAsync<T>(Guid id, IEnumerable<string>? includes, CancellationToken cancellationToken) where T : Entity;
}