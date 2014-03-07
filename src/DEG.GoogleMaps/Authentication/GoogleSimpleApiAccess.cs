using System;
using DEG.ServiceCore.Authentication;

namespace DEG.GoogleMaps.Authentication
{
    [Obsolete("This class is deprecated. Reference DEG.Google.dll and use DEG.Google.Authentication.GoogleSimpleApiAccess instead")]
    public class GoogleSimpleApiAccess : SimpleKeyAuth
    {
        public GoogleSimpleApiAccess(string apiKey) : base("key", apiKey) {}
    }
}
