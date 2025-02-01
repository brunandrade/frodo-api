using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Dtos;

public record UpdatePetDto
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public PetGenderEnum? Gender { get; set; }
    public decimal? Weight { get; set; }
    public string? ImageUrl { get; set; }
}
