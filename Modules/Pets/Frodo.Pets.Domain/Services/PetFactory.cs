using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;

namespace Frodo.Pets.Domain.Services;

public class PetFactory : IPetFactory
{
    public Pet Create(CreatePetDto createPetDto)
    {
        var pet = new Pet(createPetDto);
        return pet;
    }
}