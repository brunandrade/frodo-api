namespace Core.Api.Logs;

public class Log
{
    public string? StackTrace { get; set; }
    public string? Source { get; set; }
    public string? Message { get; set; }
    public string? InnerExceptionMessage { get; set; }
    public string Path { get; set; }
    public string Module { get; set; }
}
