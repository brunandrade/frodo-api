using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Application.Models;

public record PetModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public PetGenderEnum Gender { get; set; }
    public decimal Weight { get; set; }
    public IEnumerable<PetVaccineModel> Vaccines { get; set; }
}