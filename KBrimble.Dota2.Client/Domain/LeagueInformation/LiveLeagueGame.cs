using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.TeamInformation;

namespace KBrimble.Dota2.Client.Domain.LeagueInformation
{
    public class LiveLeagueGame
    {
        public List<TeamPlayer> Players { get; set; }
        public LiveTeam Radiant { get; set; }
        public LiveTeam Dire { get; set; }
        public long LobbyId { get; set; }
        public long MatchId { get; set; }
        public int Spectators { get; set; }
        public int LeagueId { get; set; }
        public TimeSpan StreamDelay { get; set; }
        public short RadiantSeriesWins { get; set; }
        public short DireSeriesWins { get; set; }
        public SeriesType SeriesType { get; set; }
        public int LeagueSeriesId { get; set; }
        public LeagueTier LeagueTier { get; set; }
        public Scoreboard Scoreboard { get; set; }
    }
}
