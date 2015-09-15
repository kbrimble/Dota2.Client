using KBrimble.Dota2.Client.Domain;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses.InnerResponses
{
    internal class PicksAndBansResponse
    {
        [JsonProperty("HeroId")]
        public Hero Hero { get; set; }
        public PickOrBan PickOrBan { get; set; }
        public int Order { get; set; }
        [JsonProperty("Team")]
        public Side Side { get; set; }
    }
}