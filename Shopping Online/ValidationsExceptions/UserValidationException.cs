using System;
using System.Runtime.Serialization;

namespace Shopping_Online.ValidationsExceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException()
        {
        }

        public UserValidationException(string message) : base(message)
        {
        }

        public UserValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}