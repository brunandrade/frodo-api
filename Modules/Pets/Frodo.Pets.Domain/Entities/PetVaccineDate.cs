using Core.Domain.DomainObjects;

namespace Frodo.Pets.Domain.Entities;

public class PetVaccineDate : Entity
{
    public PetVaccineDate()
    {
        
    }

    public PetVaccineDate(Guid petVaccineId, DateTime vaccinationIn, DateTime? revaccinateIn) : this()
    {
        PetVaccineId = petVaccineId;
        VaccinationIn = vaccinationIn;
        RevaccinateIn = revaccinateIn;
    }

    public Guid PetVaccineId { get; protected set; }
    public DateTime VaccinationIn { get; protected set; }
    public DateTime? RevaccinateIn { get; protected set; }
}