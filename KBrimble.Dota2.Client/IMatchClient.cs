using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using KBrimble.Dota2.Client.Requests;

namespace KBrimble.Dota2.Client
{
    public interface IMatchClient
    {
        MatchDetail GetMatch(string matchId);
        IEnumerable<MatchHistory> GetMatchHistory(MatchHistoryRequest matchHistoryRequest);
        IEnumerable<MatchHistory> GetMatchHistoryBySequenceNumber(int sequenceNumber = 0, int matchesRequested = 0);
    }
}