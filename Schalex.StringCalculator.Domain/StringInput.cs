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
            OriginalInput = input;
        }

        public bool IsSanitized { get; private set; }
        public string OriginalInput { get; private set; }
        public string SanitizedInput { get; private set; }

        public void SetSanitizedInput(string input)
        {
            IsSanitized = true;
            SanitizedInput = input;
        }
    }
}
