using DIP.Models;
using DIP.Services;
using System;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Fazle Rabbi", "0155667788");
            var shoppingCart = new ShoppingCart(3500, customer);

            var checkoutService = new CheckoutService();
            checkoutService.Checkout(shoppingCart);
        }
    }
}
