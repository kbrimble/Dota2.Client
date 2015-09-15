using System;
using System.Collections.Generic;
using AutoMapper;
using KBrimble.Dota2.Client.Configuration;
using KBrimble.Dota2.Client.Domain;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using KBrimble.Dota2.Client.Extensions;
using KBrimble.Dota2.Client.Factories;
using KBrimble.Dota2.Client.Requests;
using KBrimble.Dota2.Client.Responses;
using KBrimble.Dota2.Client.Responses.ResponseWrappers;
using RestSharp;

namespace KBrimble.Dota2.Client
{
    public class MatchClient : Dota2RestClient, IMatchClient
    {
        public MatchClient(IDota2ClientConfiguration config, IRestClientFactory clientFactory)
            : base(config, clientFactory) {}

        public MatchDetail GetMatch(string matchId)
        {
            var request = new RestRequest(RequestPaths.Dota2.Match.MatchDetails, Method.GET);
            request.AddQueryParameter("match_id", matchId);
            var response = Execute<MatchDetailResponse>(request);
            return Mapper.Map<MatchDetail>(response);
        }

        public IEnumerable<MatchHistory> GetMatchHistory(MatchHistoryRequest matchHistoryRequest)
        {
            var request = BuildRestRequestForMatchHistory(matchHistoryRequest);
            var response = Execute<MatchHistoryResponseWrapper>(request);
            return Mapper.Map<List<MatchHistory>>(response.Matches);
        }

        public IEnumerable<MatchHistory> GetMatchHistoryBySequenceNumber(int sequenceNumber = 0, int matchesRequested = 0)
        {
            var request = BuildRestRequestForMatchHistoryBySequenceNumber(sequenceNumber, matchesRequested);
            var response = Execute<MatchHistoryResponseWrapper>(request);
            return Mapper.Map<List<MatchHistory>>(response.Matches);
        }

        private static IRestRequest BuildRestRequestForMatchHistoryBySequenceNumber(int sequenceNumber,
            int matchesRequested)
        {
            var request = new RestRequest(RequestPaths.Dota2.Match.MatchHistoryBySequenceNumber);
            if (sequenceNumber > 0)
                request.AddQueryParameter("start_at_match_seq_num", sequenceNumber);
            if (matchesRequested > 0)
                request.AddQueryParameter("matches_requested", matchesRequested);
            return request;
        }

        private static IRestRequest BuildRestRequestForMatchHistory(MatchHistoryRequest mhRequest)
        {
            var request = new RestRequest(RequestPaths.Dota2.Match.MatchHistory);
            if (mhRequest.Hero != Hero.None)
                request.AddQueryParameter("hero_id", ((int) mhRequest.Hero));
            if (mhRequest.GameMode != GameMode.None)
                request.AddQueryParameter("game_mode", ((int) mhRequest.GameMode));
            if (mhRequest.Skill != SkillLevel.Any)
                request.AddQueryParameter("skill", ((int) mhRequest.Skill));
            if (mhRequest.DateMin != DateTime.MinValue)
                request.AddQueryParameter("date_min", UnixTimeStamptFromDateTime(mhRequest.DateMin));
            if (mhRequest.DateMax != DateTime.MinValue)
                request.AddQueryParameter("date_max", UnixTimeStamptFromDateTime(mhRequest.DateMax));
            if (mhRequest.MinimumPlayers > 0)
                request.AddQueryParameter("min_players", mhRequest.MinimumPlayers);
            if (mhRequest.AccountId > 0)
                request.AddQueryParameter("account_id", mhRequest.AccountId);
            if (!string.IsNullOrEmpty(mhRequest.LeagueId))
                request.AddQueryParameter("league_id", mhRequest.LeagueId);
            if (mhRequest.StartAtMatchId > 0)
                request.AddQueryParameter("start_at_match_id", mhRequest.StartAtMatchId);
            if (mhRequest.NumberOfMatchesRequested > 0)
                request.AddQueryParameter("matches_requested", mhRequest.NumberOfMatchesRequested);
            if (mhRequest.TournamentGamesOnly)
                request.AddQueryParameter("tournament_games_only", mhRequest.TournamentGamesOnly);

            return request;
        }

        private static string UnixTimeStamptFromDateTime(DateTime dt)
        {
            var rounded = new DateTime(dt.Year, dt.Month, dt.Day);
            return ((long)(rounded.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
        }
    }
}
