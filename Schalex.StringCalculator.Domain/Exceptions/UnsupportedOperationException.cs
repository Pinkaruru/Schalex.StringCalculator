using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Domain.Exceptions
{
    public class UnsupportedOperationException : StringCalculatorException
    {
        public UnsupportedOperationException()
        {
        }

        public UnsupportedOperationException(string? message) : base(message)
        {
        }

        public UnsupportedOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnsupportedOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
