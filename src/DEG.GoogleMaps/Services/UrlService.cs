using System.Linq;
using System.Web;
using DEG.GoogleMaps.Models;

namespace DEG.GoogleMaps.Services
{
    public interface IUrlService
    {
        string GetDirectionsUrlFromAddress(string address, string address2, string city, string state, string postalCode);
        string GetDirectionsUrlFromLatLong(string latitude, string longitude);
    }

    public class UrlService : IUrlService
    {
        private const string GoogleMapsUrlBase = "https://www.google.com/maps/dir/current+location/";
        private readonly IGeocodingService _geocoder;

        public UrlService(IGeocodingService geocoder)
        {
            _geocoder = geocoder;
        }
        
        public string GetDirectionsUrlFromAddress(string address, string address2, string city, string state, string postalCode)
        {
            var physicalAddress = BuildAddress(address, address2, city, state, postalCode);
            var geocodingResponse = _geocoder.LookupByAddress(physicalAddress);
            string url;

            if (IsValidGeocodingResponse(geocodingResponse))
            {
                var geolocation = geocodingResponse.Results.First().Geometry.Location;
                url = string.Format("{0}{1},{2}", GoogleMapsUrlBase, geolocation.Latitude, geolocation.Longitude);
            }
            else
            {
                url = string.Format("{0}{1}", GoogleMapsUrlBase, HttpUtility.UrlEncode(physicalAddress));
            }

            return url;
        }

        public string GetDirectionsUrlFromLatLong(string latitude, string longitude)
        {
            return string.IsNullOrWhiteSpace(latitude) || string.IsNullOrWhiteSpace(longitude)
                       ? GoogleMapsUrlBase
                       : string.Format("{0}{1},{2}", GoogleMapsUrlBase, latitude, longitude);
        }

        protected string BuildAddress(string address, string address2, string city, string state, string postalCode)
        {
            return string.Join(",", new[]
                                        {
                                            (address + " " + address2).Trim(),
                                            city,
                                            state,
                                            postalCode
                                        }
                                        .Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        protected virtual bool IsValidGeocodingResponse(GeocodingResponse result)
        {
            if (result.Status != GeocodingStatusCode.Ok || result.Results == null)
                return false;

            var location = result.Results.FirstOrDefault();
            return (location != null && location.Geometry != null && location.Geometry.Location != null);
        }        
    }
}