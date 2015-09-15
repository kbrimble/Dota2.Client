using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.TeamInformation
{
    public class Team
    {
        [JsonProperty("TeamName")]
        public string Name { get; set; }
        [JsonProperty("TeamId")]
        public long Id { get; set; }
    }
}
