using DIP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIP.Services
{
    public class CheckoutService
    {
        private readonly SMSService _smsService;

        public CheckoutService()
        {
            _smsService = new SMSService();
        }

        private void SendConfirmationSMS(ShoppingCart shoppingCart)
        {
            string message = $"Thank you, {shoppingCart.Customer.Name} for shopping at our store.\nYour order of total BDT {shoppingCart.TotalAmount} has been confirmed.";
            _smsService.SendSMS(message, shoppingCart.Customer.PhoneNumber);
        }

        public void Checkout(ShoppingCart shoppingCart)
        {
            Console.WriteLine($"Checking out {shoppingCart.Customer.Name}...");
            SendConfirmationSMS(shoppingCart);
        }
    }
}
