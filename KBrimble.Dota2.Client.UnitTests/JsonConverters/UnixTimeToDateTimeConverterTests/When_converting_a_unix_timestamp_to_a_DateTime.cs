using System;
using FluentAssertions;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.UnixTimeToDateTimeConverterTests
{
    [TestFixture]
    public class When_converting_a_unix_timestamp_to_a_DateTime
    {
        static readonly object[] SecondsToDateTimes =
        {
            new object[] { "1440440811", new DateTime(2015, 8, 24, 18, 26, 51) },
            new object[] { "1220440811", new DateTime(2008, 9, 3, 11, 20, 11) }
        };

        [Test, TestCaseSource(nameof(SecondsToDateTimes))]
        public void Positive_integers_are_deserialized_as_seconds_from_the_epoch(string input, DateTime expected)
        {
            var json = GetJsonForUnixTimeWithQuotes(input);
            var result = JsonConvert.DeserializeObject<DeserializedDateTime>(json);

            result.DateTime.Should().Be(expected);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Empty_string_values_are_parsed_as_DateTime_MinValue(string invalidInput)
        {
            var json = GetJsonForUnixTimeWithQuotes(invalidInput);
            var result = JsonConvert.DeserializeObject<DeserializedDateTime>(json);

            result.DateTime.Should().Be(DateTime.MinValue);
        }

        [TestCase("one")]
        [TestCase("NotANumber")]
        [TestCase(" ")]
        public void Strings_that_cannot_be_parsed_as_longs_are_parsed_as_DateTime_MinValue(string invalidInput)
        {
            var json = GetJsonForUnixTimeWithQuotes(invalidInput);
            var result = JsonConvert.DeserializeObject<DeserializedDateTime>(json);

            result.DateTime.Should().Be(DateTime.MinValue);
        }

        [Test]
        public void Negative_long_values_are_parsed_as_DateTime_MinValue()
        {
            var json = GetJsonForUnixTimeWithQuotes("-1");
            var result = JsonConvert.DeserializeObject<DeserializedDateTime>(json);

            result.DateTime.Should().Be(DateTime.MinValue);
        }

        [Test, TestCaseSource(nameof(SecondsToDateTimes))]
        public void Valid_long_values_without_quotes_are_parsed_correctly(string input, DateTime expected)
        {
            var json = GetJsonForUnixTime(input);
            var result = JsonConvert.DeserializeObject<DeserializedDateTime>(json);

            result.DateTime.Should().Be(expected);
        }

        private static string GetJsonForUnixTime(string input)
        {
            return $" {{ \"DateTime\" : {input} }}";
        }

        private static string GetJsonForUnixTimeWithQuotes(string input)
        {
            return GetJsonForUnixTime($"\"{input}\"");
        }
    }

    internal class DeserializedDateTime
    {
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime DateTime { get; set; }
    }
}
