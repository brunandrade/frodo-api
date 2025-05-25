using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Dtos;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain;

public class Pet : Entity, IAggregateRoot
{
    public Pet()
    {
        Tutors = new List<Tutor>();
        Vaccines = new List<Vaccine>();
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
    public DateTime DateOfBirth { get; protected set; }
    public string? MicrochipId { get; protected set; }
    public string? FavoriteFood { get; protected set; }
    public string? ImageUrl { get; protected set; }
    public ICollection<Tutor> Tutors { get; protected set; }
    public ICollection<Vaccine> Vaccines { get; protected set; }
    public ICollection<Medication> Medications { get; protected set; }

    public void AddPetUser(Guid userId)
        => Tutors.Add(new Tutor(Id, userId));

    public void Remove() => DeletedIn = DateTime.Now;

    public void Update(UpdatePetDto updatePetDto)
    {
        Name = updatePetDto.Name;
        Age = updatePetDto.Age;
        Gender = updatePetDto.Gender;
        Weight = updatePetDto.Weight;
        ImageUrl = updatePetDto.ImageUrl;
    }
}