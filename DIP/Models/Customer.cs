using System;
using System.Collections.Generic;
using System.Text;

namespace DIP.Models
{
    public class Customer
    {
        public Customer(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
