using Core.Data;
using Core.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Infra.Data;

public class FrodoContext : DbContext, IAppDBContext
{
    public FrodoContext(DbContextOptions<FrodoContext> options) : base(options)
    {
    }

    public async Task<bool> Commit(CancellationToken cancellationToken)
        => await SaveChangesAsync(cancellationToken) > 0;

    public new DbSet<T> Set<T>() where T : Entity => base.Set<T>();

    public async Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : Entity
        => await base.AddAsync(entity, cancellationToken);

    public void Update<T>(T entity) where T : Entity => base.Update(entity);
}