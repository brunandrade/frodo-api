using Ardalis.Specification;
using Core.Domain.Specification;
using Frodo.Users.Domain;

namespace Frodo.Users.Application.Specifications;

public class GetUserSpecificationByEmail : AbstractSpecification<User>
{
    public GetUserSpecificationByEmail(string email)
    {
        Query.Where(x => x.Email == email);
        Query.Where(p => !p.DeletedIn.HasValue);
    }
}