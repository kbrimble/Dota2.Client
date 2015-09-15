using System;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Domain.PlayerInformation
{
    public class AbilityUpgrade
    {
        public Ability Ability { get; set; }
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan Time { get; set; }
        public int Level { get; set; }
    }
}