using System.ComponentModel;

namespace Frodo.Users.Domain.Enums;

public enum UserStatusEnum
{
    [Description("Pendente verificação")]
    Pending = 1,

    [Description("Registrado")]
    Registered = 2,
}