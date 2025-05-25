using Frodo.Pets.Domain.Dtos;

namespace Frodo.Pets.Domain.Services;

public interface IPetFactory
{
    Pet Create(CreatePetDto createPetDto);
}

public class PetFactory : IPetFactory
{
    public Pet Create(CreatePetDto createPetDto)
    {
        var pet = new Pet(createPetDto);
        return pet;
    }
}