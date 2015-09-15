using System;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.LeagueInformation
{
    public class Scoreboard
    {
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan Duration { get; set; }
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan RoshanRespawnTime { get; set; }

        public LiveTeamDetails Radiant { get; set; }
        public LiveTeamDetails Dire { get; set; }
    }
}