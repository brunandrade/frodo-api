using Core.Domain.DomainObjects;

namespace Frodo.Pets.Domain;

public class VaccineDate : Entity
{
    public VaccineDate()
    {

    }

    public VaccineDate(Guid petVaccineId, DateTime vaccinationIn) : this()
    {
        PetVaccineId = petVaccineId;
        VaccinationIn = vaccinationIn;
    }

    public Guid PetVaccineId { get; protected set; }
    public DateTime VaccinationIn { get; protected set; }
    public DateTime RevaccinateIn { get; protected set; }
}