using Schalex.StringCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Core.Interfaces
{
    public interface IShuntingYardConverter
    {
        /// <summary>
        /// Converts a given string with mathematical expressions specified in infix notation to a Queue in RPN order. For reference: https://en.wikipedia.org/wiki/Shunting-yard_algorithm
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        Queue<string> Convert(StringInput input);
    }
}
