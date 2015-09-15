using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.TeamInformation
{
    public class ScheduledTeam : Team
    {
        [JsonProperty("Logo")]
        public long LogoId { get; set; }
    }
}