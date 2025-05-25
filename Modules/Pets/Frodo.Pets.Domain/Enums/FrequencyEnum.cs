using System.ComponentModel;

namespace Frodo.Pets.Domain.Enums;

public enum FrequencyEnum
{
    [Description("Anual")]
    Annual = 1,

    [Description("Mensal")]
    Monthly = 2,

    [Description("Semanal")]
    Weekly = 3,

    [Description("Diária")]
    Daily = 5,

    [Description("Única")]
    Single = 6,
}