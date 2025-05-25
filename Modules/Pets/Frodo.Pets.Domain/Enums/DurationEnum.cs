using System.ComponentModel;

namespace Frodo.Pets.Domain.Enums;

public enum DurationEnum
{
    [Description("7 Dias")]
    SevenDays = 1,

    [Description("15 dias")]
    FifteenDays = 2,

    [Description("30 dias")]
    ThirtyDays = 3,

    [Description("Outros")]
    Others = 4,
}