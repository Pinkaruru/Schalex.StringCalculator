using Schalex.StringCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Core.Interfaces
{
    public interface IInputSanitizer
    {
        void Sanitize(StringInput input);
    }
}
