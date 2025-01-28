using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Interfaces;

public interface IPetFactory
{
    Pet Create(string name, int age, PetGenderEnum gender, decimal weight, string imageUrl);
}