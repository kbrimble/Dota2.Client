using System.Collections.Generic;
using KBrimble.Dota2.Client.Converters;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using KBrimble.Dota2.Client.Domain.PlayerInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.LeagueInformation
{
    public class LiveTeamDetails
    {
        public int Score { get; set; }
        public TowerStatus TowerState { get; set; }
        public BarrackStatus BarracksState { get; set; }
        [JsonConverter(typeof(ArrayOfHeroIdsToListOfHeroesConverter))]
        public List<Hero> Picks { get; set; }
        [JsonConverter(typeof(ArrayOfHeroIdsToListOfHeroesConverter))]
        public List<Hero> Bans { get; set; }
        public List<LivePlayer> Players { get; set; }
    }
}