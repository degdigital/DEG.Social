using System;

namespace DEG.ServiceCore.Exceptions
{
    public class InvalidConsumerSecretException : Exception
    {
        public InvalidConsumerSecretException(string message)
            : base(message)
        {
        }
    }
}