using System;

namespace DIP.Services.SMS
{
    public class RobiSMSProvider : ISMSProvider
    {
        public void SendSMS(string text, string phoneNumber)
        {
            Console.WriteLine("Sending SMS via Robi:");
            Console.WriteLine($"Receiver: {phoneNumber}");
            Console.WriteLine($"Text: {text}");
        }
    }
}
