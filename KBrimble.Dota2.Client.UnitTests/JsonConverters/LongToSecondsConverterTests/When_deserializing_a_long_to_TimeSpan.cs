using System;
using FluentAssertions;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.LongToSecondsConverterTests
{
    [TestFixture]
    public class When_deserializing_a_long_to_TimeSpan
    {
        static readonly object[] LongsToSeconds =
        {
           new object[] { "3105", new TimeSpan(0, 0, 51, 45) },
           new object[] { "0", new TimeSpan(0, 0, 0, 0) }
        };

        [Test, TestCaseSource(nameof(LongsToSeconds))]
        public void Longs_should_be_converted_to_seconds(string input, TimeSpan expected)
        {
            var json = GetJsonForSpanWithQuotes(input);
            var result = JsonConvert.DeserializeObject<DeserializedTimeSpan>(json);

            result.Span.Should().Be(expected);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Empty_string_values_are_parsed_as_empty_time_span(string invalidInput)
        {
            var json = GetJsonForSpanWithQuotes(invalidInput);
            var result = JsonConvert.DeserializeObject<DeserializedTimeSpan>(json);

            result.Span.Should().Be(TimeSpan.MinValue);
        }

        [TestCase("one")]
        [TestCase("NotANumber")]
        [TestCase(" ")]
        public void Strings_that_cannot_be_parsed_as_longs_are_parsed_as_empty_time_span(string invalidInput)
        {
            var json = GetJsonForSpanWithQuotes(invalidInput);
            var result = JsonConvert.DeserializeObject<DeserializedTimeSpan>(json);

            result.Span.Should().Be(TimeSpan.MinValue);
        }

        [Test]
        public void Negative_long_values_are_parsed_as_empty_time_span()
        {
            var json = GetJsonForSpanWithQuotes("-1");
            var result = JsonConvert.DeserializeObject<DeserializedTimeSpan>(json);

            result.Span.Should().Be(TimeSpan.MinValue);
        }

        [Test, TestCaseSource(nameof(LongsToSeconds))]
        public void Valid_long_values_without_quotes_are_parsed_correctly(string input, TimeSpan expected)
        {
            var json = GetJsonForSpan(input);
            var result = JsonConvert.DeserializeObject<DeserializedTimeSpan>(json);

            result.Span.Should().Be(expected);
        }

        private static string GetJsonForSpan(string input)
        {
            return $" {{ \"span\" : {input} }}";
        }

        private static string GetJsonForSpanWithQuotes(string input)
        {
            return GetJsonForSpan($"\"{input}\"");
        }
    }

    internal class DeserializedTimeSpan
    {
        [JsonConverter(typeof(LongToSecondsConverter))]
        public TimeSpan Span { get; set; }  
    }
}
