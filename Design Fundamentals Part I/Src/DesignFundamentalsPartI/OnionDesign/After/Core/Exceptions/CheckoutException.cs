using System;
using System.Runtime.Serialization;

namespace OnionDesign.After.Core.Exceptions
{
    [Serializable]
    internal class CheckoutException : Exception
    {
        public CheckoutException()
        {
        }

        public CheckoutException(string message) : base(message)
        {
        }

        public CheckoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
