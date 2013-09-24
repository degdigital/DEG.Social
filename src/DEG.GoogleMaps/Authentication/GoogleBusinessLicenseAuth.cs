using DEG.ServiceCore.Authentication;

namespace DEG.GoogleMaps.Authentication
{
    public class GoogleBusinessLicenseAuth : SimpleKeyAuth
    {
        public GoogleBusinessLicenseAuth(string clientId) : base("client", clientId)
        {
        }
    }
}
