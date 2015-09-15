using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.PlayerInformation;

namespace KBrimble.Dota2.Client.Domain.MatchInformation
{
    public class MatchHistory
    {
        public long MatchId { get; set; }
        public long MatchSequenceNumber { get; set; }
        public DateTime StartTime { get; set; }
        public LobbyType LobbyType { get; set; }
        public int RadiantTeamId { get; set; }
        public int DireTeamId { get; set; }
        public List<Player> Players { get; set; }
    }
}
