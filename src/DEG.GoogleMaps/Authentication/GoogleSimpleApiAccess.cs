using DEG.Service.Core.Authentication;

namespace DEG.GoogleMaps.Authentication
{
    public class GoogleSimpleApiAccess : SimpleKeyAuth
    {
        public GoogleSimpleApiAccess(string apiKey) : base("key", apiKey) {}
    }
}
