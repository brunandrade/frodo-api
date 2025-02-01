using Frodo.Pets.Application.Commands;
using Frodo.Pets.Domain.Dtos;

namespace Frodo.Pets.Application.Extensions;

public static class UpdatePetDtoExtension
{
    public static UpdatePetDto Map(this UpdatePetCommand command, string imageUrl)
    {
        return new UpdatePetDto
        {
            Name = command.Name,
            Age = command.Age,
            Weight = command.Weight,
            Gender = command.Gender,
            ImageUrl = imageUrl,
        };
    }
}
