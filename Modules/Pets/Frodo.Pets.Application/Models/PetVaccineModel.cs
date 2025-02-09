namespace Frodo.Pets.Application.Models;

public record PetVaccineModel
{
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    public Guid MedicationId { get; set; }
    public string? DoctorName { get; set; }
    public string? Laboratory { get; set; }
    public IEnumerable<PetVaccineDateModel>? Dates { get; set; }
}

public record PetVaccineDateModel
{
    public Guid Id { get; set; }
    public Guid PetVaccineId { get; set; }
    public DateTime VaccinationIn { get; set; }
    public DateTime? RevaccinateIn { get; set; }
}