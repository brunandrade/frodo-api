using Ardalis.Specification;
using Core.Domain.Specification;
using Frodo.Pets.Domain.Entities;

namespace Frodo.Pets.Application.Specifications;

public class PetSpecification : AbstractSpecification<Pet>
{
    public PetSpecification(Guid ownerId)
    {
        Query
            .Where(p => !p.DeletedIn.HasValue)
            .Include(p => p.Users.Where(u => u.UserId == ownerId))
            .OrderBy(o => o.Name);
    }
}