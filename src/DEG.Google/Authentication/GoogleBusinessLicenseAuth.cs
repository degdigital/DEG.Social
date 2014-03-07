using DEG.ServiceCore.Authentication;

namespace DEG.Google.Authentication
{
    public class GoogleBusinessLicenseAuth : SimpleKeyAuth
    {
        public GoogleBusinessLicenseAuth(string clientId) : base("client", clientId) {}
    }
}
