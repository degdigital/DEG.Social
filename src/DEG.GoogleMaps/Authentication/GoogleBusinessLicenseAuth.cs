using System;
using DEG.ServiceCore.Authentication;

namespace DEG.GoogleMaps.Authentication
{
    [Obsolete("This class is deprecated. Reference DEG.Google.dll and use DEG.Google.Authentication.GoogleBusinessLicenseAuth instead")]
    public class GoogleBusinessLicenseAuth : SimpleKeyAuth
    {
        public GoogleBusinessLicenseAuth(string clientId) : base("client", clientId) {}
    }
}
