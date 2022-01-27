using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Domain.Exceptions
{
    public class StringCalculatorException : Exception
    {
        public StringCalculatorException()
        {
        }

        public StringCalculatorException(string? message) : base(message)
        {
        }

        public StringCalculatorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StringCalculatorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
