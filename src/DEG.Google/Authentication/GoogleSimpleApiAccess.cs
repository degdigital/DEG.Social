using DEG.ServiceCore.Authentication;

namespace DEG.Google.Authentication
{
    public class GoogleSimpleApiAccess : SimpleKeyAuth
    {
        public GoogleSimpleApiAccess(string apiKey) : base("key", apiKey) {}
    }
}
