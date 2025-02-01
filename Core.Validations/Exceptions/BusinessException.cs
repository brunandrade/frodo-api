namespace Core.Validations.Exceptions;

public class BusinessException : Exception
{
    public string Key { get; set; }
    public IEnumerable<ErrorMessage> Errors { get; set; }

    public BusinessException(IEnumerable<ErrorMessage> errors)
    {
        Key = "ValidatorErros";
        Errors = errors ?? new List<ErrorMessage>();
    }

    public BusinessException(string key, IEnumerable<ErrorMessage> errors)
    {
        Key = key;
        Errors = errors ?? new List<ErrorMessage>();
    }

    public BusinessException(string key, string message) : base(message)
    {
        Errors = new List<ErrorMessage>();
        Key = key;
    }
}
