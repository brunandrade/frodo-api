using Core.Data.Repositories;

namespace Frodo.Pets.Domain.Interfaces;

public interface IPetRepository : IRepositoryBase
{
    Task AddAsync(Pet entity, CancellationToken cancellationToken);
    void Update(Pet entity);
}