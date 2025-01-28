using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain.Entities;

public class Pet : Entity, IAggregateRoot
{
    public Pet()
    {
        PetUsers = new List<PetUser>();
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
    public ICollection<PetUser> PetUsers { get; protected set; }
}