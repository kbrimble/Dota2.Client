using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Converters;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using KBrimble.Dota2.Client.Domain.PlayerInformation;
using KBrimble.Dota2.Client.Responses.InnerResponses;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses
{
    internal class MatchDetailResponse
    {
        public List<MatchDetailPlayer> Players { get; set; }
        public bool RadiantWin { get; set; }
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan Duration { get; set; }
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime StartTime { get; set; }
        public long MatchId { get; set; }
        [JsonProperty(PropertyName = "MatchSeqNum")]
        public int MatchSequenceNumber { get; set; }
        public TowerStatus TowerStatusRadiant { get; set; }
        public TowerStatus TowerStatusDire { get; set; }
        public BarrackStatus BarracksStatusRadiant { get; set; }
        public BarrackStatus BarracksStatusDire { get; set; }
        public int Cluster { get; set; }
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan FirstBloodTime { get; set; }
        public LobbyType LobbyType { get; set; }
        public int HumanPlayers { get; set; }
        public string LeagueId { get; set; }
        public int PositiveVotes { get; set; }
        public int NegativeVotes { get; set; }
        public GameMode GameMode { get; set; }
        public int Engine { get; set; }
        [JsonProperty("PicksBans")]
        public List<PicksAndBansResponse> PicksAndBans { get; set; }
    }
}
