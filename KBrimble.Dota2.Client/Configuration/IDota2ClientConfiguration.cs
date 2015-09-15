namespace KBrimble.Dota2.Client.Configuration
{
    public interface IDota2ClientConfiguration
    {
        string BaseUrl { get; }
        string ApiKey { get; }
    }
}