using System;

namespace SRP
{
    public class EmailService
    {
        public void Validate(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is not valid!");
            }
        }
    }
}
