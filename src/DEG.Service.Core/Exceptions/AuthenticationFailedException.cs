using System;

namespace DEG.Service.Core.Exceptions
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AuthenticationFailedException(string message)
            : base(message)
        {

        }
    }
}
