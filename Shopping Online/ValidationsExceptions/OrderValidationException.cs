using System;
using System.Runtime.Serialization;

namespace Shopping_Online.ValidationsExceptions
{
    public class OrderValidationException : Exception
    {
        public OrderValidationException()
        {
        }

        public OrderValidationException(string message) : base(message)
        {
        }

        public OrderValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}