using System;

namespace DEG.ServiceCore.Exceptions
{
    public class InvalidBearerTokenException : Exception
    {
        public InvalidBearerTokenException(string message)
            : base(message)
        {
        }
    }
}