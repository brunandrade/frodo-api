namespace Core.Validations;

public class ErrorMessage
{
    public string Key { get; set; }
    public string Message { get; set; }
    public string PropertyName { get; protected set; }

    public ErrorMessage(string key, string message)
    {
        Key = key;
        Message = message;
    }

    public ErrorMessage(string key, string message, string propertyName)
    {
        Key = key;
        Message = message;
        PropertyName = propertyName;
    }
}