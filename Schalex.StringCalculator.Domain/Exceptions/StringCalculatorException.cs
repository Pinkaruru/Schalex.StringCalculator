using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Domain.Exceptions
{
    public abstract class StringCalculatorException : Exception
    {
        public string UiMessage { get; set; }

        public StringCalculatorException(string uiMessage)
        {
            UiMessage = uiMessage;
        }

        public StringCalculatorException(string uiMessage, string? message) : base(message)
        {
            UiMessage = uiMessage;
        }

        public StringCalculatorException(string uiMessage, string? message, Exception? innerException) : base(message, innerException)
        {
            UiMessage = uiMessage;
        }
    }
}
