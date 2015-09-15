using System;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;

namespace KBrimble.Dota2.Client.Converters
{
    internal class TrueFalseToPickOrBanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                var value = reader.Value.ToString().ToLowerInvariant();
                switch (value)
                {
                    case "true":
                        return PickOrBan.Pick;
                    case "false":
                        return PickOrBan.Ban;
                    default:
                        return PickOrBan.None;
                }
            }

            if (reader.ValueType == typeof(bool))
                return (bool)reader.Value ? PickOrBan.Pick : PickOrBan.Ban;

            if (reader.ValueType != typeof(long) && reader.ValueType != typeof(int) && reader.ValueType != typeof(short))
                return null;

            var intValue = (long)reader.Value;
            switch (intValue)
            {
                case 1:
                    return PickOrBan.Pick;
                case 0:
                    return PickOrBan.Ban;
                default:
                    return PickOrBan.None;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string) || objectType == typeof(bool) || objectType == typeof(int);
        }
    }
}
