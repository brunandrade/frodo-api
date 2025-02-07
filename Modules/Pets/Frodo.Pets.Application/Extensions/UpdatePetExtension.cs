using Frodo.Pets.Application.Commands;
using Frodo.Pets.Domain.Dtos;

namespace Frodo.Pets.Application.Extensions;

public static class UpdatePetExtension
{
    public static UpdatePetDto MapToDto(this UpdatePetCommand command, string imageUrl)
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

    public static UpdatePetCommand MapToCommand(this UpdatePetRequest request, Guid id)
        => new UpdatePetCommand(id, request.Name, request.Age, request.Weight, request.Gender, request.Image);
}