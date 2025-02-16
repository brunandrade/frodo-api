using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Data.Extensions;
using Core.Data.UnitOfWork;
using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Pets.Infra.Data;

public class PetRepository : IPetRepository
{
    protected readonly PetContext _petContext;

    public PetRepository(PetContext petContext)
        => _petContext = petContext;

    public IUnitOfWork IUnitOfWork => _petContext;

    public async Task AddAsync<T>(T entity, CancellationToken cancellationToken)
        => await _petContext.AddAsync(entity, cancellationToken);

    public void Update<T>(T entity)
        => _petContext.Update(entity);

    public async Task<T?> GetByIdAsync<T>(Guid id, IEnumerable<string>? includes, CancellationToken cancellationToken) where T : Entity
    {
        return await _petContext
            .Set<T>()
            .Where(x => x.Id == id && !x.DeletedIn.HasValue)
            .IncludeMultiple(includes)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>?> FindAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity
    {
        var query = _petContext.Set<T>().AsQueryable();
        query = SpecificationEvaluator.Default.GetQuery(query, spec);

        return await query.ToListAsync(cancellationToken);
    }
}