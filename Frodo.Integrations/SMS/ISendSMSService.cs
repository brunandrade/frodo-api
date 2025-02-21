namespace Frodo.Integrations.SMS;

public interface ISendSMSService
{
    Task<bool> SendSmsAsync(string port, string phoneNumber, string message);
}