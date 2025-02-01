namespace Core.Validations.Exceptions;

public class GenericException : Exception
{
    public GenericException(string key, string message) : base(message)
    {
        Key = key;
    }

    public string Key { get; set; }
}
