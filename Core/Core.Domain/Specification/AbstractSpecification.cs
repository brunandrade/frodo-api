using Ardalis.Specification;
using Core.Domain.DomainObjects;

namespace Core.Domain.Specification;

public abstract class AbstractSpecification<T> : Specification<T> where T : Entity
{
}