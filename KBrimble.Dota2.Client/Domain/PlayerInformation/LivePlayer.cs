using System;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.PlayerInformation
{
    public class LivePlayer : Player
    {
        public LivePlayerSlot PlayerSlot { get; set; }
        [JsonProperty("Death")]
        public int Deaths { get; set; }
        [JsonProperty("UltimateState")]
        public UltimateStatus UltimateAvailable { get; set; }
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan UltimateCooldown { get; set; }
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan RespawnTimer { get; set; }
        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }
        public int NetWorth { get; set; }
    }
}
