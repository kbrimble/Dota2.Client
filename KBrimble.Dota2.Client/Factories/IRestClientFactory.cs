using KBrimble.Dota2.Client.Configuration;
using RestSharp;

namespace KBrimble.Dota2.Client.Factories
{
    public interface IRestClientFactory
    {
        IRestClient GetClient(IDota2ClientConfiguration config);
    }
}