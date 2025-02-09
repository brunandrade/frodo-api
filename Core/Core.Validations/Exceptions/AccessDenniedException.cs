namespace Core.Validations.Exceptions;

public class AccessDenniedException : GenericException
{
    public AccessDenniedException(string key, string message) : base(key, message)
    {
    }
}