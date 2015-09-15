using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses
{
    internal class LeagueResponse
    {
        public string Description { get; set; }
        [JsonProperty("Itemdef")]
        public int ItemId { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string TournamentUrl { get; set; }
    }
}
