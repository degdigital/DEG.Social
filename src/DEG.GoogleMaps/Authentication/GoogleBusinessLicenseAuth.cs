using DEG.Service.Core.Authentication;

namespace DEG.GoogleMaps.Authentication
{
    public class GoogleBusinessLicenseAuth : SimpleKeyAuth
    {
        public GoogleBusinessLicenseAuth(string clientId) : base("client", clientId)
        {
        }
    }
}
