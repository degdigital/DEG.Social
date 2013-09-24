using System;

namespace DEG.ServiceCore.Exceptions
{
    public class InvalidConsumerKeyException : Exception
    {
        public InvalidConsumerKeyException(string message)
            : base(message)
        {
        }
    }
}