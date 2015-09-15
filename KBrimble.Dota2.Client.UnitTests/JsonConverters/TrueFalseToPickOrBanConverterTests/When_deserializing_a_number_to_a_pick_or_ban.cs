using FluentAssertions;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.TrueFalseToPickOrBanConverterTests
{
    [TestFixture]
    public class When_deserializing_a_number_to_a_pick_or_ban : PickOrBanConverterTestsBase
    {
        [TestCase(1, PickOrBan.Pick)]
        [TestCase(0, PickOrBan.Ban)]
        public void Integer_value_of_1_is_converted_to_Pick_and_0_is_converted_to_Ban(int input, PickOrBan expected)
        {
            var json = GetJsonForPickOrBan(input.ToString().ToLowerInvariant());
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(expected);
        }

        [TestCase(1L, PickOrBan.Pick)]
        [TestCase(0L, PickOrBan.Ban)]
        public void Long_value_of_1_is_converted_to_Pick_and_0_is_converted_to_Ban(long input, PickOrBan expected)
        {
            var json = GetJsonForPickOrBan(input.ToString().ToLowerInvariant());
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(expected);
        }

        [TestCase(1, PickOrBan.Pick)]
        [TestCase(0, PickOrBan.Ban)]
        public void Short_value_of_1_is_converted_to_Pick_and_0_is_converted_to_Ban(short input, PickOrBan expected)
        {
            var json = GetJsonForPickOrBan(input.ToString().ToLowerInvariant());
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(expected);
        }

        [TestCase(2)]
        [TestCase(-1)]
        [TestCase(100000)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(long.MaxValue)]
        public void All_other_values_are_converted_to_None(long input)
        {
            var json = GetJsonForPickOrBan(input.ToString().ToLowerInvariant());
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(PickOrBan.None);
        }
    }
}
