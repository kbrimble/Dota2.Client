using AutoMapper;
using KBrimble.Dota2.Client.Domain.LeagueInformation;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using KBrimble.Dota2.Client.Responses;
using KBrimble.Dota2.Client.Responses.InnerResponses;

namespace KBrimble.Dota2.Client.Configuration
{
    internal class ClassMappings
    {
        internal static void EnsureMappings()
        {
            Mapper.CreateMap<PicksAndBansResponse, PicksAndBans>();
            Mapper.CreateMap<MatchDetailResponse, MatchDetail>();
            Mapper.CreateMap<MatchHistoryResponse, MatchHistory>();
            Mapper.CreateMap<League, LeagueResponse>();
            Mapper.CreateMap<LiveLeagueGame, LiveLeagueGameResponse>();
            Mapper.CreateMap<ScheduledGame, ScheduledGameResponse>();
            Mapper.CreateMap<LeaguePrizePool, LeaguePrizePoolResponse>();
        }
    }
}
