using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Entities;

namespace Frodo.Pets.Domain.Interfaces;

public interface IPetFactory
{
    Pet Create(CreatePetDto createPetDto);
}