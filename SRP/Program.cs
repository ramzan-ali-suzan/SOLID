using System;
using System.Net.Mail;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class UserNameService
        {
            public void Validate(string firstName, string lastName)
            {
                if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName))
                {
                    throw new Exception("The name is invalid!");
                }
            }
        }

        public class EmailService
        {
            public void Validate(string email)
            {
                if (!email.Contains("@") || !email.Contains("."))
                {
                    throw new Exception("Email is not valid!!");
                }
            }
        }

        public class InvitationService
        {
            UserNameService _userNameService;
            EmailService _emailService;

            public InvitationService(UserNameService userNameService, EmailService emailService)
            {
                _userNameService = userNameService;
                _emailService = emailService;
            }

            public void SendInvite(string email, string firstName, string lastName)
            {
                _userNameService.Validate(firstName, lastName);
                _emailService.Validate(email);
                SmtpClient client = new SmtpClient();
                client.Send(new MailMessage("mysite@nowhere.com", email) { Subject = "Please join me at my party!" });
            }
        }
    }
}
