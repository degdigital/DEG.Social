using System;

namespace DEG.Service.Core.Exceptions
{
    public class InvalidConsumerSecretException : Exception
    {
        public InvalidConsumerSecretException(string message)
            : base(message)
        {
        }
    }
}