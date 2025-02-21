using Ardalis.Specification;
using Core.Domain.Specification;
using Frodo.Users.Domain;

namespace Frodo.Users.Application.Specifications;

public class UserSpecification : AbstractSpecification<User>
{
    public UserSpecification(string email)
    {
        Query.Where(x => x.Email == email);
        Query.Where(p => !p.DeletedIn.HasValue);
        Query.OrderBy(o => o.Name);
    }
}