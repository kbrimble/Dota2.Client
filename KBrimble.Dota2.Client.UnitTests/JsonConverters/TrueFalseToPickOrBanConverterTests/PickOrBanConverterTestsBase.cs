using KBrimble.Dota2.Client.Converters;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.TrueFalseToPickOrBanConverterTests
{
    public abstract class PickOrBanConverterTestsBase
    {
        protected static string GetJsonForPickOrBan(string input)
        {
            return $" {{ \"PickOrBan\" : {input} }}";
        }

        protected static string GetJsonForPickOrBanWithQuotes(string input)
        {
            return GetJsonForPickOrBan($"\"{input}\"");
        }

        internal class DeserializedPickOrBan
        {
            [JsonConverter(typeof(TrueFalseToPickOrBanConverter))]
            public PickOrBan PickOrBan { get; set; }
        }
    }
}
