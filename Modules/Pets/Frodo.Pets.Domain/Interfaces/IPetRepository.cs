using Core.Data.Repositories;
using Frodo.Pets.Domain.Entities;

namespace Frodo.Pets.Domain.Interfaces;

public interface IPetRepository : IRepositoryBase
{
    Task AddAsync(Pet entity, CancellationToken cancellationToken);
    void Update(Pet entity);
}