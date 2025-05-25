using Ardalis.Specification;
using Core.Domain.Specification;
using Frodo.Users.Domain;

namespace Frodo.Users.Application.Specifications;

public class GetUserSpecificationByUserName : AbstractSpecification<User>
{
    public GetUserSpecificationByUserName(string username)
    {
        Query.Where(x => x.UserName == username);

        Query.Where(p => !p.DeletedIn.HasValue);
    }
}