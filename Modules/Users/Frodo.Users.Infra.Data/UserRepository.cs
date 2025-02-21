using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Data.Extensions;
using Core.Data.UnitOfWork;
using Core.Domain.DomainObjects;
using Frodo.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Users.Infra.Data;

public class UserRepository : IUserRepository
{
    protected UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public IUnitOfWork IUnitOfWork => _userContext;

    public async Task AddAsync<T>(T entity, CancellationToken cancellationToken)
        => await _userContext.AddAsync(entity, cancellationToken);

    public void Update<T>(T entity)
        => _userContext.Update(entity);

    public async Task<T?> GetByIdAsync<T>(Guid id, IEnumerable<string>? includes, CancellationToken cancellationToken) where T : Entity
    {
        return await _userContext
            .Set<T>()
            .Where(x => x.Id == id && !x.DeletedIn.HasValue)
            .IncludeMultiple(includes)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>?> FindAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity
    {
        var query = _userContext.Set<T>().AsQueryable();
        query = SpecificationEvaluator.Default.GetQuery(query, spec);

        return await query.ToListAsync(cancellationToken);
    }
}