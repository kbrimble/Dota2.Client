using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.LeagueInformation
{
    public class TeamPlayer
    {
        public long AccountId { get; set; }
        public string Name { get; set; }
        [JsonProperty("HeroId")]
        public Hero Hero { get; set; }
        public Side Team { get; set; }
    }
}