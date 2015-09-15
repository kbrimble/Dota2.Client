using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.TeamInformation;

namespace KBrimble.Dota2.Client.Domain.LeagueInformation
{
    public class ScheduledGame
    {
        public int LeagueId { get; set; }
        public int GameId { get; set; }
        public List<ScheduledTeam> Teams { get; set; }
        public DateTime StartTime { get; set; }
        public string Comment { get; set; }
        public bool IsFinal { get; set; }
    }
}
