using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.PlayerInformation;

namespace KBrimble.Dota2.Client.Domain.MatchInformation
{
    public class MatchDetail
    {
        public List<MatchDetailPlayer> Players { get; set; }
        public bool RadiantWin { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public long MatchId { get; set; }
        public int MatchSequenceNumber { get; set; }
        public TowerStatus TowerStatusRadiant { get; set; }
        public TowerStatus TowerStatusDire { get; set; }
        public BarrackStatus BarracksStatusRadiant { get; set; }
        public BarrackStatus BarracksStatusDire { get; set; }
        public int Cluster { get; set; }
        public TimeSpan FirstBloodTime { get; set; }
        public LobbyType LobbyType { get; set; }
        public int HumanPlayers { get; set; }
        public string LeagueId { get; set; }
        public int PositiveVotes { get; set; }
        public int NegativeVotes { get; set; }
        public GameMode GameMode { get; set; }
        public int Engine { get; set; }
        public List<PicksAndBans> PicksAndBans { get; set; }
    }
}
