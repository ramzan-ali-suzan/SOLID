using DIP.Services.SMS;

namespace DIP.Services
{
    public class SMSService
    {
        private readonly ISMSProvider _smsProvider;

        public SMSService(ISMSProvider smsProvider)
        {
            _smsProvider = smsProvider;
        }

        public void SendSMS(string text, string phoneNumber)
        {
            _smsProvider.SendSMS(text, phoneNumber);
        }
    }
}
