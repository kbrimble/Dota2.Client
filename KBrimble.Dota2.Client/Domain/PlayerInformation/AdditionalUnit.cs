using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KBrimble.Dota2.Client.Domain.PlayerInformation
{
    public class AdditionalUnit
    {
        [JsonProperty(PropertyName = "unitname")]
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        [JsonExtensionData]
        // ReSharper disable once CollectionNeverUpdated.Local
        private readonly IDictionary<string, JToken> _additionalItemData;

        private const string ItemKeyPattern = "item_?[0-5]";

        protected AdditionalUnit()
        {
            _additionalItemData = new Dictionary<string, JToken>();
        }

        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            Items = new List<Item>();
            var keys = _additionalItemData.Keys.Where(x => Regex.IsMatch(x, ItemKeyPattern, RegexOptions.IgnoreCase));
            foreach (var itemKey in keys)
            {
                Items.Add((Item)_additionalItemData[itemKey].Value<int>());
            }
        }

    }
}