using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;
using Frodo.Pets.Domain.Interfaces;

namespace Frodo.Pets.Domain.Services;

public class PetFactory : IPetFactory
{
    public Pet Create(string name, int age, PetGenderEnum gender, decimal weight, string imageUrl)
    {
        var pet = new Pet(name, age, gender, weight, imageUrl);
        return pet;
    }
}