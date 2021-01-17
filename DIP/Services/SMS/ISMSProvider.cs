namespace DIP.Services.SMS
{
    public interface ISMSProvider
    {
        public void SendSMS(string text, string phoneNumber);
    }
}
