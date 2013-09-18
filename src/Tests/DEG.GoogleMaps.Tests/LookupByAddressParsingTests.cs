using System.IO;
using System.Linq;
using DEG.GoogleMaps.Models;
using DEG.Service.Core.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.GoogleMaps.Tests
{
    [TestFixture]
    public class LookupByAddressParsingTests
    {
        private readonly GeocodingResponse _results;

        public LookupByAddressParsingTests()
        {
            var file = File.OpenText(@".\Data\Response1.json");

            _results = JsonHelper.Parse<GeocodingResponse>(file.ReadToEnd());
        }

        [Test]
        public void ParsedCorrectNumberOfAddressResponses()
        {
            _results.Results.Should().HaveCount(1);
        }

        [Test]
        public void ParsedLatitude()
        {
            _results.Results.First().Geometry.Location.Latitude.Should().Be(37.42291810m);
        }

        [Test]
        public void ParsedLongitude()
        {
            _results.Results.First().Geometry.Location.Longitude.Should().Be(-122.08542120m);
        }

        [Test]
        public void ParsedLocationType()
        {
            _results.Results.First().Geometry.LocationType.Should().Be("ROOFTOP");
        }

        [Test]
        public void ParsedTypes()
        {
            _results.Results.First().Types.Should().Contain("street_address");
        }

        [Test]
        public void ParsedStatus()
        {
            _results.Status.Should().Be("OK");
        }
    }
}
