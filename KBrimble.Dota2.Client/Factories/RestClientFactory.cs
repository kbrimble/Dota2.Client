using KBrimble.Dota2.Client.Configuration;
using RestSharp;

namespace KBrimble.Dota2.Client.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient GetClient(IDota2ClientConfiguration config)
        {
            return new RestClient(config.BaseUrl);
        }
    }
}
