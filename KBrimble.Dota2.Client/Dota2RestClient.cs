using System.Net;
using System.Net.Http;
using KBrimble.Dota2.Client.Configuration;
using KBrimble.Dota2.Client.ContractResolvers;
using KBrimble.Dota2.Client.Factories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KBrimble.Dota2.Client
{
    public abstract class Dota2RestClient
    {
        private readonly IDota2ClientConfiguration _configuration;
        private readonly IRestClientFactory _clientFactory;

        protected Dota2RestClient(IDota2ClientConfiguration configuration, IRestClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
            ClassMappings.EnsureMappings();
        }

        protected T Execute<T>(IRestRequest request) where T : new()
        {
            AddApiKeyToRequest(request);

            var client = _clientFactory.GetClient(_configuration);
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.ErrorMessage);

            return IgnoreRootElementDeserialize<T>(response.Content);
        }

        private static T IgnoreRootElementDeserialize<T>(string json) where T : new()
        {
            var jObj = JObject.Parse(json);
            var root = jObj?.First;
            var first = root?.First;
            if (first == null) return default(T);

            var serializer = new JsonSerializer { ContractResolver = new SnakeCaseContractResolver() };
            return serializer.Deserialize<T>(first.CreateReader());
        }

        private void AddApiKeyToRequest(IRestRequest request)
        {
            request.AddQueryParameter("key", _configuration.ApiKey);
        }
    }
}
