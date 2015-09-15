using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KBrimble.Dota2.Client.Domain.TeamInformation
{
    public class TeamDetails
    {
        [JsonProperty("TeamId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime TimeCreated { get; set; }
        [JsonProperty("Rating")]
        public TeamStatus Status { get; set; }
        [JsonProperty("Logo")]
        public long LogoId { get; set; }
        [JsonProperty("LogoSponsor")]
        public long SponsorLogoId { get; set; }
        public string CountryCod { get; set; }
        public int GamesPlayedWithCurrentRoster { get; set; }
        public long AdminAccountId { get; set; }
        public List<long> PlayerAccountIds { get; set; }
        public List<int> LeagueIds { get; set; }

        [JsonExtensionData]
        // ReSharper disable once CollectionNeverUpdated.Local
        private readonly IDictionary<string, JToken> _additionalTeamData;

        private const string PlayerIdKeyPattern = "player_[0-9]_account_id";
        private const string LeagueIdKeyPattern = "league_id_\\d{1,2}(?!\\d)|100";

        protected TeamDetails()
        {
            _additionalTeamData = new Dictionary<string, JToken>();
        }

        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            AddPlayerAccountIdsFromAdditionalData();
            AddLeagueIdsFromAdditionalData();
        }

        protected void AddPlayerAccountIdsFromAdditionalData()
        {
            PlayerAccountIds = new List<long>();
            var keys = _additionalTeamData.Keys.Where(x => Regex.IsMatch(x, PlayerIdKeyPattern, RegexOptions.IgnoreCase));
            foreach (var itemKey in keys)
            {
                PlayerAccountIds.Add(_additionalTeamData[itemKey].Value<long>());
            }
        }

        protected void AddLeagueIdsFromAdditionalData()
        {
            LeagueIds = new List<int>();
            var keys = _additionalTeamData.Keys.Where(x => Regex.IsMatch(x, LeagueIdKeyPattern, RegexOptions.IgnoreCase));
            foreach (var itemKey in keys)
            {
                LeagueIds.Add(_additionalTeamData[itemKey].Value<int>());
            }
        }
    }
}
