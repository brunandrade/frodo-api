﻿using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Entities;

public class Pet : Entity, IAggregateRoot
{
    public Pet()
    {
        Users = new List<PetUser>();
        Vaccines = new List<PetVaccine>();
    }

    public Pet(CreatePetDto createPetDto) : this()
    {
        Name = createPetDto.Name;
        Age = createPetDto.Age;
        Gender = createPetDto.Gender;
        Weight = createPetDto.Weight;
        Race = createPetDto.Race;
        ImageUrl = createPetDto.ImageUrl;

        AddPetUser(createPetDto.UserId);
    }

    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public PetGenderEnum Gender { get; protected set; }
    public decimal Weight { get; protected set; }
    public string Race { get; protected set; }
    public string? ImageUrl { get; protected set; }
    public ICollection<PetUser> Users { get; protected set; }
    public ICollection<PetVaccine> Vaccines { get; protected set; }

    public PetVaccine AddPetVaccine(CreatePetVaccineDto createPetVaccineDto)
    {
        var petVaccine = new PetVaccine(createPetVaccineDto);
        Vaccines.Add(petVaccine);
        return petVaccine;
    }

    public void AddPetUser(Guid userId)
        => Users.Add(new PetUser(Id, userId));

    public void Remove()=> DeletedIn = DateTime.Now;

    public void Update(UpdatePetDto updatePetDto)
    {
        Name = updatePetDto.Name;
        Age = updatePetDto.Age;
        Gender = updatePetDto.Gender;
        Weight = updatePetDto.Weight;
        ImageUrl = updatePetDto.ImageUrl;
    }
}