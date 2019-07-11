using System;
using System.Runtime.Serialization;

namespace Shopping_Online.ValidationsExceptions
{
    public class ProductValidationException : Exception
    {
        public ProductValidationException()
        {
        }

        public ProductValidationException(string message) : base(message)
        {
        }

        public ProductValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}