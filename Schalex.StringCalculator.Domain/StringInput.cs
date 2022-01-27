using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Domain
{
    public class StringInput
    {
        public StringInput(string input)
        {
            Input = input;
        }

        public bool IsSanitized { get; private set; }
        public string Input { get; private set; }

        public void SetSanitizedInput(string sanitizedInput)
        {
            IsSanitized = true;
            Input = sanitizedInput;
        }
    }
}
