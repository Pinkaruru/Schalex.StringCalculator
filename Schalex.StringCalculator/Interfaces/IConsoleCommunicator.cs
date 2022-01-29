using Schalex.StringCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Interfaces
{
    public interface IConsoleCommunicator
    {
        void PrintGreeting();
        string GetInput();
        void PrintResult(StringInput input, int result);
    }
}
