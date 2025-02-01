using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Interfaces;

namespace Frodo.Pets.Domain.Services;

public class CreatePetVaccineService : ICreatePetVaccineService
{
    public Pet Create(Pet pet, CreatePetVaccineDto createPetVaccineDto)
    {
        pet.AddPetVaccine(createPetVaccineDto);
        return pet;
    }
}