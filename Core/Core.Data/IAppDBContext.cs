using Core.Data.UnitOfWork;
using Core.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Core.Data;

public interface IAppDBContext : IUnitOfWork
{
    DbSet<T> Set<T>() where T : Entity;
    Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : Entity;
    void Update<T>(T entity) where T : Entity;
}