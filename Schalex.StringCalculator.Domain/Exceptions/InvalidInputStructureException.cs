using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Domain.Exceptions
{
    public class InvalidInputStructureException : StringCalculatorException
    {
        public InvalidInputStructureException()
        {
        }

        public InvalidInputStructureException(string? message) : base(message)
        {
        }

        public InvalidInputStructureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidInputStructureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
