using System;

namespace DEG.Service.Core.Exceptions
{
    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException(string message)
            : base(message)
        {
        }
    }
}