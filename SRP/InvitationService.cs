using System;

namespace SRP
{
    public class InvitationService
    {
        UserNameService userNameService = new UserNameService();
        EmailService emailService = new EmailService();

        public void SendInvite(string email, string firstName, string lastName)
        {
            userNameService.Validate(firstName, lastName);
            emailService.Validate(email);

            Console.WriteLine($"\nSending invitation to {firstName} {lastName}, at email {email}...\n");
        }
    }
}
