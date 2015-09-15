using AutoMapper;
using NUnit.Framework;

namespace KBrimble.Dota2.Client.UnitTests.ClassMappings
{
    [TestFixture]
    public class When_mapping_response_objects_to_public_data_objects
    {
        [Test]
        public void AutoMapper_mappings_should_be_correctly_configured()
        {
            Configuration.ClassMappings.EnsureMappings();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
