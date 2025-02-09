using System.ComponentModel;

namespace Core.Common.Extensions;

public static class EnumExtensions
{
    public static T GetEnumValue<T>(this Enum valorEnum) where T : Attribute
    {
        var type = valorEnum.GetType();
        var memInfo = type.GetMember(valorEnum.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0 ? (T)attributes[0] : null;
    }

    public static string GetDescription(this Enum valorEnum)
        => valorEnum.GetEnumValue<DescriptionAttribute>().Description;
}