namespace Core.Validations.Exceptions;

public class UnauthorizedException : GenericException
{
    public UnauthorizedException(string key, string message) : base(key, message)
    {
    }
}