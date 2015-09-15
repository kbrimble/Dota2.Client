using System;
using KBrimble.Dota2.Client.Domain;
using KBrimble.Dota2.Client.Domain.MatchInformation;

namespace KBrimble.Dota2.Client.Requests
{
    public class MatchHistoryRequest
    {
        public Hero Hero { get; set; }
        public GameMode GameMode { get; set; }
        public SkillLevel Skill { get; set; }
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public short MinimumPlayers { get; set; }
        public long AccountId { get; set; }
        public string LeagueId { get; set; }
        public long StartAtMatchId { get; set; }
        public int NumberOfMatchesRequested { get; set; }
        public bool TournamentGamesOnly { get; set; }
    }
}