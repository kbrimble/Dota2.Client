namespace KBrimble.Dota2.Client.Requests
{
    public static class RequestPaths
    {
        private const string Version = "v1";

        public static class Dota2
        {
            private const string BaseUrl = "IDOTA2Match_570";

            public static class Match
            {
                public static string MatchDetails = string.Join("/", BaseUrl, "GetMatchDetails", Version);
                public static string MatchHistory = string.Join("/", BaseUrl, "GetMatchHistory", Version);
                public static string MatchHistoryBySequenceNumber = string.Join("/", BaseUrl, "GetMatchHistoryBySequenceNum", Version);
            }

            public static class League
            {
                public static string LeagueListing = string.Join("/", BaseUrl, "GetLeagueListing", Version);
                public static string LeaguePrizePool = string.Join("/", "IEconDOTA2_570", "GetTournamentPrizePool", Version);
                public static string LiveLeagueGames = string.Join("/", BaseUrl, "GetLiveLeagueGames", Version);
                public static string ScheduledLeagueGames = string.Join("/", BaseUrl, "GetScheduledLeagueGames", Version);
            }
        }
    }
}
