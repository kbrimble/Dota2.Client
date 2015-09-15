using System;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Converters
{
    internal class LongToSecondsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            float f;
            var parsed = float.TryParse(reader.Value.ToString(), out f);
            var l = Convert.ToInt64(f);
            return !parsed || l < 0 ? TimeSpan.MinValue : TimeSpan.FromSeconds(l);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (int);
        }
    }
}
