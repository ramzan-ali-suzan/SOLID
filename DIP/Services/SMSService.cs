using System;
using System.Collections.Generic;
using System.Text;

namespace DIP.Services
{
    public class SMSService
    {
        public void SendSMS(string text, string phoneNumber)
        {
            Console.WriteLine("Sending SMS via GP:");
            Console.WriteLine($"Receiver: {phoneNumber}");
            Console.WriteLine($"Text: {text}");
        }
    }
}
