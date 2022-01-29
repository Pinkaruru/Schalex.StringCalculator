using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Domain;
using Schalex.StringCalculator.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Core.Services
{
    public class Calculator : ICalculator
    {
        private readonly IInputSanitizer sanitizer;
        private readonly IInputValidator validator;
        private readonly IShuntingYardConverter converter;

        public Calculator(IInputSanitizer sanitizer, IInputValidator validator, IShuntingYardConverter converter)
        {
            this.sanitizer = sanitizer ?? throw new ArgumentNullException(nameof(sanitizer));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public int Calculate(StringInput input)
        {
            sanitizer.Sanitize(ref input);
            validator.Validate(input);
            var rpnQueue = converter.Convert(input);

            var rpnCalculationStack = new Stack<int>();
            foreach(var rpnToken in rpnQueue)
            {
                if(int.TryParse(rpnToken, out int number))
                {
                    rpnCalculationStack.Push(number);
                    continue;
                }

                switch (rpnToken)
                {
                    case "+":
                        rpnCalculationStack.Push(rpnCalculationStack.Pop() + rpnCalculationStack.Pop());
                        break;
                    case "-":
                        number = rpnCalculationStack.Pop();
                        rpnCalculationStack.Push(rpnCalculationStack.Pop() - number);
                        break;
                    default:
                        throw new InvalidOperationException($"Operation with operator '{rpnToken}' not supported.");
                }
            }

            return rpnCalculationStack.Pop();
        }
    }
}
