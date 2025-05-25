using System.ComponentModel;

namespace Frodo.Pets.Domain.Enums;

public enum VaccinationTypeEnum
{
    [Description("Preventiva")]
    Preventative = 1,

    [Description("Vermifugação")]
    Deworming = 2,

    [Description("Ectoparasitas")]
    Ectoparasites = 3,

    [Description("Outras")]
    Others = 5,
}