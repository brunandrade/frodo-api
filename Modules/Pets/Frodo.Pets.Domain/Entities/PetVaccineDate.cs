using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Entities;

public class PetVaccineDate : Entity
{
    public PetVaccineDate()
    {
        
    }

    public PetVaccineDate(Guid petVaccineId, DateTime revaccinateIn) : this()
    {
        PetVaccineId = petVaccineId;
        RevaccinateIn = revaccinateIn;
    }

    public Guid PetVaccineId { get; protected set; }
    public DateTime RevaccinateIn { get; protected set; }
}