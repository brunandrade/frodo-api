using System.ComponentModel;

namespace Frodo.Pets.Domain.Enums;

public enum PetGenderEnum
{
    [Description("Macho")]
    Male = 1,

    [Description("Femea")]
    Female = 2,
}