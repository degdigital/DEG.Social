using DEG.ServiceCore.Authentication;

namespace DEG.GoogleMaps.Authentication
{
    public class GoogleSimpleApiAccess : SimpleKeyAuth
    {
        public GoogleSimpleApiAccess(string apiKey) : base("key", apiKey) {}
    }
}
