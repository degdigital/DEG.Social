using System.Linq;
using DEG.GoogleMaps.Models;
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

        [Test]
        [Category("Integration")]
        public void CanStrictlyGeofenceLookupRequests()
        {
            var service = new GeocodingService(new NoAuthentication(), false);
            var result = service
                .LookupByAddressInBounds("Balmoral", new GeocodingGeometryLocationBounds
                                                         {
                                                             Southwest = new GeocodingGeometryLocation { Latitude = 72.228294m, Longitude = -169.136192m },
                                                             Northeast = new GeocodingGeometryLocation { Latitude = 20.635313m, Longitude = -47.878356m }
                                                         }, true);

            result.Results.Should().BeEmpty();
        }

        [Test]
        [Category("Integration")]
        public void LookupByBoundsCanStillReturnOutsideResults()
        {
            var service = new GeocodingService(new NoAuthentication(), false);
            var result = service
                .LookupByAddressInBounds("Balmoral", new GeocodingGeometryLocationBounds
                {
                    Southwest = new GeocodingGeometryLocation { Latitude = 72.228294m, Longitude = -169.136192m },
                    Northeast = new GeocodingGeometryLocation { Latitude = 20.635313m, Longitude = -47.878356m }
                });

            result.Results.Should().NotBeEmpty();
        }
    }
}
