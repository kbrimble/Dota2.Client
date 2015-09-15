using System.Collections.Generic;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Responses.ResponseWrappers
{
    internal class MatchHistoryResponseWrapper
    {
        public MatchHistoryStatus Status { get; set; }
        public string StatusDetail { get; set; }
        [JsonProperty(PropertyName = "num_results")]
        public int NumberOfResults { get; set; }
        public int TotalResults { get; set; }
        public int ResultsRemaining { get; set; }
        public List<MatchHistoryResponse> Matches { get; set; }
    }
}
