using System.ComponentModel;

namespace Frodo.Pets.Domain.Enums;

public enum VaccinationFrequencyEnum
{
    [Description("Mensal")]
    Monthly = 1,

    [Description("Semanal")]
    Weekly = 2,

    [Description("Anual")]
    Annual = 3,

    [Description("Personalizado")]
    Personalized = 4,

    [Description("Única")]
    Single = 5,
}