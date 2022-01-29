using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Domain.Exceptions
{
    public class InvalidInputCharactersException : StringCalculatorException
    {
        public InvalidInputCharactersException()
        {
        }

        public InvalidInputCharactersException(string? message) : base(message)
        {
        }

        public InvalidInputCharactersException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidInputCharactersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
