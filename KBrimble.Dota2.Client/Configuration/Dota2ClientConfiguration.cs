namespace KBrimble.Dota2.Client.Configuration
{
    public class Dota2ClientConfiguration : IDota2ClientConfiguration
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
    }
}