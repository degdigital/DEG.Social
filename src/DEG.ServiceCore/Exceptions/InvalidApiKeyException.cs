using System;

namespace DEG.ServiceCore.Exceptions
{
    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException(string message)
            : base(message)
        {
        }
    }
}