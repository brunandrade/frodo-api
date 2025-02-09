using Core.Common.Extensions;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Application.Models;

public record PetModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public PetGenderEnum Gender { get; set; }
    public string GenderName => Gender.GetDescription();
    public decimal Weight { get; set; }
    public string Race { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedIn { get; set; }
    public DateTime UpdatedIn { get; set; }
    public IEnumerable<PetUser> Users { get; set; }
    public IEnumerable<PetVaccineModel> Vaccines { get; set; }
}