using System.Web;
using DEG.GoogleMaps.Models;
using DEG.ServiceCore;
using DEG.ServiceCore.Authentication;

namespace DEG.GoogleMaps
{
    public interface IGeocodingService
    {
        GeocodingResponse LookupByAddress(string address);
    }

    //https://developers.google.com/maps/documentation/geocoding/
    //Google Maps API v3
    public class GeocodingService : ServiceBase, IGeocodingService
    {
        private readonly bool _deviceHasGpsSensor;
        internal const string GeocodingUrl = "http://maps.googleapis.com/maps/api/geocode/json";

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
    }
}
