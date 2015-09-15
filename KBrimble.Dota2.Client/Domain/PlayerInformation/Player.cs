using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KBrimble.Dota2.Client.Domain.PlayerInformation
{
    public abstract class Player
    {
        public long AccountId { get; set; }
        [JsonProperty(PropertyName = "HeroId")]
        public Hero Hero { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public List<Item> Items { get; set; }
        public int Gold { get; set; }
        public int LastHits { get; set; }
        public int Denies { get; set; }
        public int GoldPerMin { get; set; }
        public int XpPerMin { get; set; }
        public int Level { get; set; }


        [JsonExtensionData]
        // ReSharper disable once CollectionNeverUpdated.Local
        private readonly IDictionary<string, JToken> _additionalPlayerData;

        private const string ItemKeyPattern = "item_?[0-5]";

        protected Player()
        {
            _additionalPlayerData = new Dictionary<string, JToken>();
        }

        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            AddItemsFromAdditionalData();
        }

        protected void AddItemsFromAdditionalData()
        {
            Items = new List<Item>();
            var keys = _additionalPlayerData.Keys.Where(x => Regex.IsMatch(x, ItemKeyPattern, RegexOptions.IgnoreCase));
            foreach (var itemKey in keys)
            {
                Items.Add((Item)_additionalPlayerData[itemKey].Value<int>());
            }
        }
    }
}