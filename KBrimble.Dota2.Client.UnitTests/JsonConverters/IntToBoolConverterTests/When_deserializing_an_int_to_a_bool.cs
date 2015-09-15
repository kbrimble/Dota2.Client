using FluentAssertions;
using KBrimble.Dota2.Client.Converters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.IntToBoolConverterTests
{
    [TestFixture]
    class When_deserializing_an_int_to_a_bool
    {
        [TestCase(1, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(2, false)]
        [TestCase(int.MinValue, false)]
        [TestCase(int.MaxValue, false)]
        public void One_is_deserialized_to_true_all_other_values_are_false(int input, bool expected)
        {
            var json = GetJsonForInt(input.ToString());
            var result = JsonConvert.DeserializeObject<DeserializedBool>(json);

            result.Bool.Should().Be(expected);
        }

        [TestCase(1, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(2, false)]
        [TestCase(int.MinValue, false)]
        [TestCase(int.MaxValue, false)]
        public void With_quotes_one_is_deserialized_to_true_all_other_values_are_false(int input, bool expected)
        {
            var json = GetJsonForIntWithQuotes(input.ToString());
            var result = JsonConvert.DeserializeObject<DeserializedBool>(json);

            result.Bool.Should().Be(expected);
        }

        private static string GetJsonForInt(string input)
        {
            return $" {{ \"bool\" : {input} }}";
        }

        private static string GetJsonForIntWithQuotes(string input)
        {
            return GetJsonForInt($"\"{input}\"");
        }
    }

    internal class DeserializedBool
    {
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool Bool { get; set; }
    }
}
