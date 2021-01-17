using DIP.Models;
using DIP.Services;
using DIP.Services.SMS;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Fazle Rabbi", "0155667788");
            var shoppingCart = new ShoppingCart(3500, customer);

            //var smsProvider = new GPSMSProvider();
            var smsProvider = new RobiSMSProvider();
            var smsService = new SMSService(smsProvider);

            var checkoutService = new CheckoutService(smsService);
            checkoutService.Checkout(shoppingCart);
        }
    }
}
