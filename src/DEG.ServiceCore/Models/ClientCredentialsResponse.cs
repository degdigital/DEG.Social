using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DEG.ServiceCore.Models
{
    [DataContract]
    public class ClientCredentialsResponse
    {
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "errors")]
        public IEnumerable<ServiceErrorResponse> Errors { get; set; }
    }

    [DataContract]
    public class ServiceErrorResponse
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
