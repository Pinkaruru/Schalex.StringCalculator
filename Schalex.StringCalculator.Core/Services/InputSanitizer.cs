using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Core.Services
{
    public class InputSanitizer : IInputSanitizer
    {
        public void Sanitize(ref StringInput input)
        {
            input.SetSanitizedInput(Regex.Replace(input.OriginalInput, @"\s", ""));
        }
    }
}
