using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Converters;
using KBrimble.Dota2.Client.Domain.LeagueInformation;
using KBrimble.Dota2.Client.Domain.TeamInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses
{
    internal class LiveLeagueGameResponse
    {
        public List<TeamPlayer> Players { get; set; }
        [JsonProperty("RadiantTeam")]
        public LiveTeam Radiant { get; set; }
        [JsonProperty("DireTeam")]
        public LiveTeam Dire { get; set; }
        public long LobbyId { get; set; }
        public long MatchId { get; set; }
        public int Spectators { get; set; }
        public int LeagueId { get; set; }
        [JsonProperty("StreamDelayS"), JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan StreamDelay { get; set; }
        public short RadiantSeriesWins { get; set; }
        public short DireSeriesWins { get; set; }
        public SeriesType SeriesType { get; set; }
        public int LeagueSeriesId { get; set; }
        public LeagueTier LeagueTier { get; set; }
        public Scoreboard Scoreboard { get; set; }
    }
}
