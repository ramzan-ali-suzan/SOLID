using System;
using System.Collections.Generic;
using System.Text;

namespace DIP.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(double totalAmount, Customer customer)
        {
            this.TotalAmount = totalAmount;
            this.Customer = customer;
        }

        public double TotalAmount { get; private set; }
        public Customer Customer { get; private set; }
    }
}
