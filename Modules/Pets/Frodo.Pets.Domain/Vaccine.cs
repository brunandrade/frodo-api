using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain;

public class Vaccine : Entity
{
    public Vaccine()
    {
        Dates = new List<VaccineDate>();
    }

    public Guid PetId { get; protected set; }
    public VaccinationTypeEnum Type { get; protected set; }
    public FrequencyEnum Frequency { get; protected set; }
    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public string? DoctorName { get; protected set; }
    public string? Laboratory { get; protected set; }
    public ICollection<VaccineDate> Dates { get; protected set; }

    public void Remove()
        => DeletedIn = DateTime.Now;
}