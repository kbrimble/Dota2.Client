using System;
using System.Collections.Generic;
using System.Linq;
using KBrimble.Dota2.Client.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KBrimble.Dota2.Client.Converters
{
    internal class ArrayOfHeroIdsToListOfHeroesConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObj = JToken.ReadFrom(reader);
            var children = jObj.Children();
            return children.Values().Select(child => Convert.ToInt32(child.First.Value<long>())).Cast<Hero>().ToList();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsInstanceOfType(typeof(List<Hero>));
        }
    }
}