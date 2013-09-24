using DEG.ServiceCore.Authentication;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.GoogleMaps.Tests
{
    [TestFixture]
    public class GeocodingServiceTests
    {
        [Test]
        [Category("Integration")]
        public void CanLookupByAddress()
        {
            var service = new GeocodingService(new NoAuthentication(), false);
            var result = service.LookupByAddress("10801 Mastin Blvd, Overland Park, KS");

            result.Results.Should().NotBeEmpty();
        }
    }
}
