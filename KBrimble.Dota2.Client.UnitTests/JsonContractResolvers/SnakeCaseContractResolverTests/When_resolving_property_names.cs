using FluentAssertions;
using KBrimble.Dota2.Client.ContractResolvers;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.JsonContractResolvers.SnakeCaseContractResolverTests
{
    [TestFixture]
    public class When_resolving_property_names
    {
        private SnakeCaseContractResolver _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SnakeCaseContractResolver();
        }

        [TestCase("Property", "property")]
        [TestCase("MultiWordProperty", "multi_word_property")]
        [TestCase("PropertyWithNumbers0", "property_with_numbers_0")]
        public void PascalCase_strings_will_resolve_to_snake_case(string pascal, string expected)
        {
            var result = _sut.GetResolvedPropertyName(pascal);

            result.Should().Be(expected);
        }
    }
}
