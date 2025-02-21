using System.IO.Ports;

namespace Frodo.Integrations.SMS;

public class SendSMSService : ISendSMSService
{
    public async Task<bool> SendSmsAsync(string port, string phoneNumber, string message)
    {
        using SerialPort serialPort = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);

        try
        {
            serialPort.Open();
            await Task.Delay(500);

            serialPort.WriteLine("AT\r");
            await Task.Delay(500);

            serialPort.WriteLine("AT+CMGF=1\r");
            await Task.Delay(500);

            serialPort.WriteLine($"AT+CMGS=\"{phoneNumber}\"\r");
            await Task.Delay(500);

            serialPort.WriteLine(message + char.ConvertFromUtf32(26));
            await Task.Delay(500);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar SMS: {ex.Message}");
            return false;
        }
        finally
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }
    }
}