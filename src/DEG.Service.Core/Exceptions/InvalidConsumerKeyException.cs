using System;

namespace DEG.Service.Core.Exceptions
{
    public class InvalidConsumerKeyException : Exception
    {
        public InvalidConsumerKeyException(string message)
            : base(message)
        {
        }
    }
}