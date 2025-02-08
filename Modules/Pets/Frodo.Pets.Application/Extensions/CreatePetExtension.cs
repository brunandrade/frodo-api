using Frodo.Pets.Application.Commands;
using Frodo.Pets.Domain.Dtos;

namespace Frodo.Pets.Application.Extensions;

public static class CreatePetExtension
{
    public static CreatePetDto MapToDto(this CreatePetCommand command, string imageUrl)
    {
        return new CreatePetDto
        {
            Name = command.Name,
            Age = command.Age,
            Weight = command.Weight,
            Gender = command.Gender,
            Race = command.Race,
            ImageUrl = imageUrl,
        };
    }
}
