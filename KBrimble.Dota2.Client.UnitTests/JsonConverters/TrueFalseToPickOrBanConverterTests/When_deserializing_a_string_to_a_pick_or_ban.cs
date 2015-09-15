using System;
using FluentAssertions;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.TrueFalseToPickOrBanConverterTests
{
    [TestFixture]
    class When_deserializing_a_string_to_a_pick_or_ban : PickOrBanConverterTestsBase
    {
        [TestCase("true", PickOrBan.Pick)]
        [TestCase("false", PickOrBan.Ban)]
        public void Boolean_values_as_strings_are_correctly_deserialized_as_a_PickOrBan(string input, PickOrBan expected)
        {
            var json = GetJsonForPickOrBanWithQuotes(input);
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(expected);
        }

        [TestCase("True")]
        [TestCase("TRUE")]
        [TestCase("False")]
        [TestCase("FALSE")]
        [TestCase("invalid")]
        public void Any_value_other_than_true_or_false_throws_exception_if_not_surrounded_by_quotes(string invalidValue)
        {
            var json = GetJsonForPickOrBan(invalidValue);
            Action action = () => JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);
            action.ShouldThrow<Exception>();
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("anything else")]
        public void Values_other_than_true_or_false_are_deserialized_as_None(string invalidValue)
        {
            var json = GetJsonForPickOrBanWithQuotes(invalidValue);
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(PickOrBan.None);
        }
    }
}
