using Ardalis.Specification;
using Core.Domain.Specification;
using Frodo.Pets.Domain;

namespace Frodo.Pets.Application.Specifications;

public class PetSpecification : AbstractSpecification<Pet>
{
    public PetSpecification(Guid tutorId)
    {
        Query
            .Where(p => !p.DeletedIn.HasValue)
            .Include(p => p.Tutors.Where(u => u.UserId == tutorId))
            .OrderBy(o => o.Name);
    }
}