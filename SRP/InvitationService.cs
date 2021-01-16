using System;

namespace SRP
{
    public class InvitationService
    {
        public void SendInvite(string email, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Name is not valid!");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Email is not valid!");
            }

            Console.WriteLine($"Sending invitation to {firstName} {lastName}, at email {email}...");
            Console.ReadKey();
        }
    }
}
