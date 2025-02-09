using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Entities;

public class PetVaccine : Entity
{
    public PetVaccine()
    {
        Dates = new List<PetVaccineDate>();
    }

    public PetVaccine(CreatePetVaccineDto createPetVaccineDto) : this()
    {
        PetId = createPetVaccineDto.PetId;
        MedicationId = createPetVaccineDto.MedicationId;
        VaccinationIn = createPetVaccineDto.VaccinationIn;
        Frequency = createPetVaccineDto.Frequency;
        NumberOfDays = createPetVaccineDto.NumberOfDays;
        DoctorName = createPetVaccineDto.DoctorName;
        Laboratory = createPetVaccineDto.Laboratory;
    }

    public Guid PetId { get; protected set; }
    public Guid MedicationId { get; protected set; }
    public string? DoctorName { get; protected set; }
    public string? Laboratory { get; protected set; }
    public DateTime VaccinationIn { get; protected set; }
    public VaccinationFrequencyEnum Frequency { get; protected set; }
    public int? NumberOfDays { get; protected set; }
    public ICollection<PetVaccineDate> Dates { get; protected set; }

    public void AddPetVaccineDate(DateTime revaccinateIn)
        => Dates.Add(new PetVaccineDate(Id, revaccinateIn));

    public void Remove() 
        => DeletedIn = DateTime.Now;
}