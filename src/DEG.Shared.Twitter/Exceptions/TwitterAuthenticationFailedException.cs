﻿using System;

namespace DEG.Shared.Twitter.Exceptions
{
    public class TwitterAuthenticationFailedException : ApplicationException
    {
        public TwitterAuthenticationFailedException(string message) : base(message)
        {
        }
    }
}
