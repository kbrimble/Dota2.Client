using System;
using System.Collections.Generic;
using AutoMapper;
using KBrimble.Dota2.Client.Configuration;
using KBrimble.Dota2.Client.Domain.LeagueInformation;
using KBrimble.Dota2.Client.Extensions;
using KBrimble.Dota2.Client.Factories;
using KBrimble.Dota2.Client.Requests;
using KBrimble.Dota2.Client.Responses;
using KBrimble.Dota2.Client.Responses.ResponseWrappers;
using RestSharp;

namespace KBrimble.Dota2.Client
{
    public class LeagueClient : Dota2RestClient, ILeagueClient
    {
        public LeagueClient(IDota2ClientConfiguration config, IRestClientFactory clientFactory)
            : base(config, clientFactory) {}

        public IEnumerable<League> GetLeagueListing(string language = "en")
        {
            var request = new RestRequest(RequestPaths.Dota2.League.LeagueListing);
            request.AddQueryParameter("language", language);
            var response = Execute<LeagueListingResponseWrapper>(request);
            return Mapper.Map<List<League>>(response.Leagues);
        }

        public IEnumerable<LiveLeagueGame> GetLiveLeagueGames()
        {
            var request = new RestRequest(RequestPaths.Dota2.League.LiveLeagueGames);
            var response = Execute<LiveListingResponseWrapper>(request);
            return Mapper.Map<List<LiveLeagueGame>>(response.Games);
        }

        public IEnumerable<ScheduledGame> GetScheduledLeagueGames(DateTime dateMin = default(DateTime), DateTime dateMax = default(DateTime))
        {
            var request = new RestRequest(RequestPaths.Dota2.League.ScheduledLeagueGames);

            var defaultDateTime = default(DateTime);
            if (dateMin != defaultDateTime)
                request.AddQueryParameter("date_min", dateMin.ToUnixTime());
            if (dateMax != defaultDateTime)
                request.AddQueryParameter("date_max", dateMax.ToUnixTime());

            var response = Execute<ScheduledLeagueGamesResponseWrapper>(request);
            return Mapper.Map<List<ScheduledGame>>(response.Games);
        }

        public LeaguePrizePool GetPrizePoolForLeague(int leagueId)
        {
            var request = new RestRequest(RequestPaths.Dota2.League.LeaguePrizePool);
            request.AddQueryParameter("leagueid", leagueId);

            var response = Execute<LeaguePrizePoolResponse>(request);
            return Mapper.Map<LeaguePrizePool>(response);
        }
    }
}
