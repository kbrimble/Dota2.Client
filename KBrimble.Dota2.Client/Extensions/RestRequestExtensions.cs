using RestSharp;

namespace KBrimble.Dota2.Client.Extensions
{
    internal static class RestRequestExtensions
    {
        public static void AddQueryParameter(this RestRequest request, string key, object value)
        {
            request.AddQueryParameter(key, value.ToString());
        }
    }
}
