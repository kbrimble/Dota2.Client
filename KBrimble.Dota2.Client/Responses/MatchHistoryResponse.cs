using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Converters;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using KBrimble.Dota2.Client.Domain.PlayerInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses
{
    internal class MatchHistoryResponse
    {
        public long MatchId { get; set; }
        [JsonProperty(PropertyName = "MatchSeqNum")]
        public long MatchSequenceNumber { get; set; }
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime StartTime { get; set; }
        public LobbyType LobbyType { get; set; }
        public int RadiantTeamId { get; set; }
        public int DireTeamId { get; set; }
        public List<Player> Players { get; set; }
    }
}
