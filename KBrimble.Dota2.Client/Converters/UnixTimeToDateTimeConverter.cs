using System;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Converters
{
    internal class UnixTimeToDateTimeConverter : JsonConverter
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long l;
            var parsed = long.TryParse(reader.Value.ToString(), out l);
            return !parsed || l < 0
                ? DateTime.MinValue
                : _epoch.AddSeconds(l);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime) value - _epoch).TotalMilliseconds + "000");
        }
    }
}
