using FluentAssertions;
using KBrimble.Dota2.Client.Domain.MatchInformation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonConverters.TrueFalseToPickOrBanConverterTests
{
    public class When_deserializing_a_bool_to_a_pick_or_ban : PickOrBanConverterTestsBase
    {
        [TestCase(true, PickOrBan.Pick)]
        [TestCase(false, PickOrBan.Ban)]
        public void True_is_converted_to_Pick_and_false_is_converted_to_Ban(bool input, PickOrBan expected)
        {
            var json = GetJsonForPickOrBan(input.ToString().ToLowerInvariant());
            var result = JsonConvert.DeserializeObject<DeserializedPickOrBan>(json);

            result.PickOrBan.Should().Be(expected);
        }
    }
}
