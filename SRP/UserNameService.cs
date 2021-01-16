using System;

namespace SRP
{
    public class UserNameService
    {
        public void Validate(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("The user name is invalid!");
            }
        }
    }
}
