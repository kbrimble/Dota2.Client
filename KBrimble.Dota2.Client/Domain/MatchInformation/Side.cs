using System;

namespace KBrimble.Dota2.Client.Domain.MatchInformation
{
    [Flags]
    public enum Side
    {
        Radiant = 0,
        Dire = 1,
        Broadcaster = 2,
        Unassigned = 4
    }
}