using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Dtos;

public record CreatePetVaccineDto
{
    public Guid PetId { get; set; }
    public Guid MedicationId { get; set; }
    public DateTime VaccinationIn { get; set; }
    public VaccinationFrequencyEnum Frequency { get; set; }
    public int? NumberOfDays { get; set; }
    public string? DoctorName { get; set; }
    public string? Laboratory { get; set; }
}