using System;

namespace DIP.Services.SMS
{
    public class GPSMSProvider : ISMSProvider
    {
        public void SendSMS(string text, string phoneNumber)
        {
            Console.WriteLine("Sending SMS via GP:");
            Console.WriteLine($"Receiver: {phoneNumber}");
            Console.WriteLine($"Text: {text}");
        }
    }
}
