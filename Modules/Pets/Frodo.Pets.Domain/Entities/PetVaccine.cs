using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Dtos;

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
        DoctorName = createPetVaccineDto.DoctorName;
        Laboratory = createPetVaccineDto.Laboratory;

        AddPetVaccineDate(createPetVaccineDto.VaccinationIn, createPetVaccineDto.RevaccinateIn);
    }

    public Guid PetId { get; protected set; }
    public Guid MedicationId { get; protected set; }
    public string? DoctorName { get; protected set; }
    public string? Laboratory { get; protected set; }
    public ICollection<PetVaccineDate> Dates { get; protected set; }

    public void AddPetVaccineDate(DateTime vaccinationIn, DateTime? revaccinateIn)
    {
        var vaccineDate = new PetVaccineDate(Id, vaccinationIn, revaccinateIn);
        Dates.Add(vaccineDate);
    }

    public void Remove() => DeletedIn = DateTime.Now;
}