using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.TeamInformation
{
    public class LiveTeam : Team
    {
        [JsonProperty("TeamLogo")]
        public long LogoId { get; set; }
        public bool Complete { get; set; }
    }
}