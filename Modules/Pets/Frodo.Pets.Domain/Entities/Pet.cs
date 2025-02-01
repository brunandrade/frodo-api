using Azure;
using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Enums;
using System.Reflection;

namespace Frodo.Pets.Domain.Entities;

public class Pet : Entity, IAggregateRoot
{
    public Pet()
    {
        Users = new List<PetUser>();
        Vaccines = new List<PetVaccine>();
    }

    public Pet(string name, int age, PetGenderEnum gender, decimal weight, string imageUrl) : this()
    {
        Name = name;
        Age = age;
        Gender = gender;
        Weight = weight;
        ImageUrl = imageUrl;
    }

    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public PetGenderEnum Gender { get; protected set; }
    public decimal Weight { get; protected set; }
    public string? ImageUrl { get; protected set; }
    public ICollection<PetUser> Users { get; protected set; }
    public ICollection<PetVaccine> Vaccines { get; protected set; }

    public void AddPetVaccine(CreatePetVaccineDto createPetVaccineDto)
    {
        var vaccine = new PetVaccine();
        Vaccines.Add(vaccine);
    }

    public void Update(UpdatePetDto updatePetDto)
    {
        Name = updatePetDto.Name ?? Name;
        Age = updatePetDto.Age ?? Age;
        Gender = updatePetDto.Gender ?? Gender;
        Weight = updatePetDto.Weight ?? Weight;
        ImageUrl = updatePetDto.ImageUrl ?? ImageUrl;
    }
}