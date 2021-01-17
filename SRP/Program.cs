using SRP.Services;
using System;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var invitationService = new InvitationService();

                while (true)
                {
                    // Taking input
                    Console.WriteLine("Enter participant first name:");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Enter participant last name:");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter participant email address:");
                    string email = Console.ReadLine();

                    // Sending Invitation
                    invitationService.SendInvite(email, firstName, lastName);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
