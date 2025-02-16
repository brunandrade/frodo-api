using Core.Common.Extensions;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Application.Models;

public record PetVaccineModel
{
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    public Guid MedicationId { get; set; }
    public DateTime VaccinationIn { get; set; }
    public VaccinationFrequencyEnum Frequency { get; set; }
    public string FrequencyName => Frequency.GetDescription();
    public int? NumberOfDays { get; set; }
    public string? DoctorName { get; set; }
    public string? Laboratory { get; set; }
    public DateTime CreatedIn { get; set; }
    public DateTime UpdatedIn { get; set; }
    public IEnumerable<PetVaccineDateModel>? Dates { get; set; }
}

public record PetVaccineDateModel
{
    public Guid Id { get; set; }
    public Guid PetVaccineId { get; set; }
    public DateTime? RevaccinateIn { get; set; }
    public DateTime CreatedIn { get; set; }
    public DateTime UpdatedIn { get; set; }
}