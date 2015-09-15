namespace KBrimble.Dota2.Client.Domain.MatchInformation
{
    public class PicksAndBans
    {
        public Hero Hero { get; set; }
        public PickOrBan PickOrBan { get; set; }
        public int Order { get; set; }
        public Side Side { get; set; }
    }
}