using System;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            var invitationService = new InvitationService();
            invitationService.SendInvite("hasan@mail.com", "Hasan", "Imam");
        }
    }
}
