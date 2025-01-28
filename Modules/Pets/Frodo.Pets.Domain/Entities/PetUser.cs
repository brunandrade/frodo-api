using Core.Domain.DomainObjects;

namespace Frodo.Pets.Domain.Entities;

public class PetUser : Entity
{
    public PetUser()
    {
        
    }
    public PetUser(Guid petId, Guid userId) : this()
    {
        PetId = petId;
        UserId = userId;
    }

    public Guid PetId { get; protected set; }
    public Guid UserId { get; protected set; }
}