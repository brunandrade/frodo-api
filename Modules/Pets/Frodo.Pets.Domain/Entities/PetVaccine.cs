using Core.Domain.DomainObjects;

namespace Frodo.Pets.Domain.Entities;

public class PetVaccine : Entity
{
    public PetVaccine()
    {
        Dates = new List<PetVaccineDate>();
    }

    public Guid PetId { get; protected set; }
    public Guid MedicationId { get; protected set; }
    public string? DoctorName { get; protected set; }
    public string? Laboratory { get; protected set; }
    public ICollection<PetVaccineDate> Dates { get; protected set; }
}