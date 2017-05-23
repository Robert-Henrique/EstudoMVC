using System;

namespace Business
{
    public sealed class BusinessException : Exception
    {
        public BusinessException(string message, Exception source) : base(message, source) { }
    }
}
