using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Dtos;

public record BasePetDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public PetGenderEnum Gender { get; set; }
    public decimal Weight { get; set; }
    public string Race { get; set; }
    public string ImageUrl { get; set; }
}

public record CreatePetDto : BasePetDto
{
}

public record UpdatePetDto : BasePetDto
{
}
