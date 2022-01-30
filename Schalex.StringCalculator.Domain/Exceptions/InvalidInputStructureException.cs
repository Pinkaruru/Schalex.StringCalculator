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
        public InvalidInputStructureException(string uiMessage) : base(uiMessage)
        {
        }

        public InvalidInputStructureException(string uiMessage, string? message) : base(uiMessage, message)
        {
        }

        public InvalidInputStructureException(string uiMessage, string? message, Exception? innerException) : base(uiMessage, message, innerException)
        {
        }
    }
}
