using System;
using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.LeagueInformation;

namespace KBrimble.Dota2.Client
{
    public interface ILeagueClient
    {
        IEnumerable<League> GetLeagueListing(string language = "en");
        IEnumerable<LiveLeagueGame> GetLiveLeagueGames();
        IEnumerable<ScheduledGame> GetScheduledLeagueGames(DateTime dateMin = default(DateTime), DateTime dateMax = default(DateTime));
    }
}