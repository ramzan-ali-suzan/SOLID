using System;

namespace SRP.Services
{
    public class InvitationService
    {
        public void SendInvite(string email, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Name is not valid!");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is not valid!");
            }

            Console.WriteLine($"\nSending invitation to {firstName} {lastName}, at email {email}...\n");
        }
    }
}
