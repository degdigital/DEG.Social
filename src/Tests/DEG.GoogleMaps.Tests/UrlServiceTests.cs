using DEG.GoogleMaps.Services;
using DEG.ServiceCore.Authentication;
using NUnit.Framework;
using FluentAssertions;

namespace DEG.GoogleMaps.Tests
{
    [TestFixture]
    public class UrlServiceTests
    {
        [Test]
        public void UsesLatLongIfAddressExists()
        {
            const string expectedUrl = "https://www.google.com/maps/dir/current+location/38.9328641,-94.70196319999999";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromAddress("10801 Mastin St", "#130", "Overland Park", "KS", "66210");
            directionsUrl.Should().Be(expectedUrl);
        }
       
        [Test]
        public void CorrectlyHandlesInvalidAddress()
        {
            const string expectedUrl =
                "https://www.google.com/maps/dir/current+location/asdfasdfasdfas%2casdfasdfasdfas%2casdfasdfasdfas%2c00000";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromAddress("asdfasdfasdfas", null, "asdfasdfasdfas", "asdfasdfasdfas", "00000");
            directionsUrl.Should().Be(expectedUrl);
        }

        [Test]
        public void CorrectlyHandlesNullAddress()
        {
            const string expectedUrl = "https://www.google.com/maps/dir/current+location/";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromAddress(null, null, null, null, null);
            directionsUrl.Should().Be(expectedUrl);
        }

        [Test]
        public void GetsCorrectUrlFromLatLong()
        {
            const string expectedUrl = "https://www.google.com/maps/dir/current+location/38.9328641,-94.70196319999999";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromLatLong("38.9328641", "-94.70196319999999");
            directionsUrl.Should().Be(expectedUrl);
        }

        [Test]
        public void CorrectlyHandlesNullLatLong()
        {
            const string expectedUrl = "https://www.google.com/maps/dir/current+location/";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromLatLong(null, null);
            directionsUrl.Should().Be(expectedUrl);
        }

        [Test]
        public void CorrectlyHandlesNullLatitude()
        {
            const string expectedUrl = "https://www.google.com/maps/dir/current+location/";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromLatLong("38.9328641", null);
            directionsUrl.Should().Be(expectedUrl);
        }

        [Test]
        public void CorrectlyHandlesNullLongitude()
        {
            const string expectedUrl = "https://www.google.com/maps/dir/current+location/";
            var service = GetUrlService();
            var directionsUrl = service.GetDirectionsUrlFromLatLong(null, "38.9328641");
            directionsUrl.Should().Be(expectedUrl);
        }

        private static UrlService GetUrlService()
        {
            return new UrlService(new GeocodingService(new NoAuthentication(), false));
        }
    }
}
