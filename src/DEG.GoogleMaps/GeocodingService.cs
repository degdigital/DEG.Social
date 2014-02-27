using System.Linq;
using System.Web;
using DEG.GoogleMaps.Models;
using DEG.ServiceCore;
using DEG.ServiceCore.Authentication;

namespace DEG.GoogleMaps
{
    public interface IGeocodingService
    {
        GeocodingResponse LookupByAddress(string address);
        GeocodingResponse LookupByAddressInBounds(string address, GeocodingGeometryLocationBounds bounds, bool strict = false);
    }

    //https://developers.google.com/maps/documentation/geocoding/
    //Google Maps API v3
    public class GeocodingService : ServiceBase, IGeocodingService
    {
        private readonly bool _deviceHasGpsSensor;
        internal const string GeocodingUrl = "https://maps.googleapis.com/maps/api/geocode/json";

        public GeocodingService(IServiceAuth auth, bool deviceHasGpsSensor) : base(auth)
        {
            _deviceHasGpsSensor = deviceHasGpsSensor;
        }
        
        public GeocodingResponse LookupByAddress(string address)
        {
            var url = GeocodingUrl +
                      "?sensor=" + _deviceHasGpsSensor.ToString().ToLowerInvariant() +
                      "&address=" + HttpUtility.UrlEncode(address);

            return GetObject<GeocodingResponse>(url);
        }

        public GeocodingResponse LookupByAddressInBounds(string address, GeocodingGeometryLocationBounds bounds, bool strict = false)
        {
            var url = GeocodingUrl +
                      "?sensor=" + _deviceHasGpsSensor.ToString().ToLowerInvariant() +
                      "&address=" + HttpUtility.UrlEncode(address) +
                      string.Format("&bounds={0},{1}|{2},{3}",
                                    bounds.Southwest.Latitude, bounds.Southwest.Longitude,
                                    bounds.Northeast.Latitude, bounds.Northeast.Longitude);

            var result = GetObject<GeocodingResponse>(url);
            if (!strict) return result;

            result.Results = result.Results
                .Where(x => LocationIsWithinBounds(x.Geometry.Location, bounds))
                .ToArray();
            return result;
        }

        private static bool LocationIsWithinBounds(GeocodingGeometryLocation location, GeocodingGeometryLocationBounds bounds)
        {
            if (location.Latitude < bounds.Southwest.Latitude) return false;
            if (location.Latitude > bounds.Northeast.Latitude) return false;
            if (location.Longitude < bounds.Southwest.Longitude) return false;
            if (location.Longitude > bounds.Northeast.Longitude) return false;
            return true;
        }
    }
}
