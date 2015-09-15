using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Converters;
using KBrimble.Dota2.Client.Domain.TeamInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses
{
    internal class ScheduledGameResponse
    {
        public int LeagueId { get; set; }
        public int GameId { get; set; }
        public List<ScheduledTeam> Teams { get; set; }
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime StartTime { get; set; }
        public string Comment { get; set; }
        [JsonProperty("Final")]
        public bool IsFinal { get; set; }
    }
}
