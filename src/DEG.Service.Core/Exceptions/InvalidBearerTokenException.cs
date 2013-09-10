using System;

namespace DEG.Service.Core.Exceptions
{
    public class InvalidBearerTokenException : Exception
    {
        public InvalidBearerTokenException(string message)
            : base(message)
        {
        }
    }
}