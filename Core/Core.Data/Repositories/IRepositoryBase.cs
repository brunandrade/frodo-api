using Ardalis.Specification;
using Core.Data.UnitOfWork;
using Core.Domain.DomainObjects;

namespace Core.Data.Repositories;

public interface IRepositoryBase
{
    IUnitOfWork IUnitOfWork { get; }
    Task<T?> GetByIdAsync<T>(Guid id, IEnumerable<string>? includes, CancellationToken cancellationToken) where T : Entity;
    Task<IEnumerable<T>?> FindAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity;
}