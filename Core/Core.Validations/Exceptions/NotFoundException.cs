namespace Core.Validations.Exceptions;

public class NotFoundException : GenericException
{
    public NotFoundException(string key, string message) : base(key, message)
    {
    }
}
