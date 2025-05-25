using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Data;
using Core.Data.Extensions;
using Core.Data.UnitOfWork;
using Core.Domain.DomainObjects;
using Frodo.Pets.Domain;
using Frodo.Pets.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Pets.Infra.Data;

public class PetRepository(IAppDBContext context) : IPetRepository
{
    protected readonly IAppDBContext _context = context;

    public IUnitOfWork IUnitOfWork => _context;

    public async Task AddAsync(Pet entity, CancellationToken cancellationToken)
        => await _context.AddAsync(entity, cancellationToken);

    public void Update(Pet entity)
        => _context.Update(entity);

    public async Task<T?> GetByIdAsync<T>(Guid id, IEnumerable<string>? includes, CancellationToken cancellationToken) where T : Entity
    {
        return await _context
            .Set<T>()
            .Where(x => x.Id == id && !x.DeletedIn.HasValue)
            .IncludeMultiple(includes)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>?> FindAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity
    {
        var query = _context.Set<T>().AsQueryable();
        query = SpecificationEvaluator.Default.GetQuery(query, spec);

        return await query.ToListAsync(cancellationToken);
    }
}