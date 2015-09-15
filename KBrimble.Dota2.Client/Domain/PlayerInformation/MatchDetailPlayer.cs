using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.MatchInformation;

namespace KBrimble.Dota2.Client.Domain.PlayerInformation
{
    public class MatchDetailPlayer : Player
    {
        public int Deaths { get; set; }
        public LeaverStatus LeaverStatus { get; set; }
        public int GoldSpent { get; set; }
        public int HeroDamage { get; set; }
        public int TowerDamage { get; set; }
        public int HeroHealing { get; set; }
        public MatchDetailPlayerSlot PlayerSlot { get; set; }
        public List<AbilityUpgrade> AbilityUpgrades { get; set; }
        public List<AdditionalUnit> AdditionalUnits { get; set; }
    }
}
