using Core.Data.Repositories;

namespace Frodo.Users.Domain;

public interface IUserRepository : IRepositoryBase
{
    Task AddAsync(User entity, CancellationToken cancellationToken);
    void Update(User entity);
}