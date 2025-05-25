using Core.Domain.DomainObjects;

namespace Frodo.Pets.Domain;

public class Tutor : Entity
{
    public Tutor()
    {

    }
    public Tutor(Guid petId, Guid userId) : this()
    {
        PetId = petId;
        UserId = userId;
        Active = true;
    }

    public Guid PetId { get; protected set; }
    public Guid UserId { get; protected set; }
    public bool Active { get; protected set; }
}