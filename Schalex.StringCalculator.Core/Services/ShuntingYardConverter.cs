using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Core.Services
{
    public class ShuntingYardConverter : IShuntingYardConverter
    {
        
        public Queue<string> Convert(StringInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (!input.IsSanitized)
            {
                throw new ArgumentException($"{nameof(input)} is not sanitized");
            }

            var rpnQueue = new Queue<string>();
            var operatorStack = new Stack<char>();
            var stringBuilder = new StringBuilder();
            var charArrlength = input.SanitizedInput.Length;
            char currentChar;
            for (int i = 0; i < charArrlength; i++)
            {
                currentChar = input.SanitizedInput[i];
                if (currentChar == '(')
                {
                    operatorStack.Push(currentChar);
                }

                if (currentChar == ')')
                {
                    while(operatorStack.Peek() != '(')
                    {
                        rpnQueue.Enqueue(operatorStack.Pop().ToString());
                    }

                    operatorStack.Pop(); // remove last opening parantheses
                }

                if (currentChar == '+' || currentChar == '-')
                {
                    rpnQueue.Enqueue(stringBuilder.ToString());
                    stringBuilder.Clear();

                    if(operatorStack.Count != 0 && (operatorStack.Peek() == '+' || operatorStack.Peek() == '-'))
                    {
                        rpnQueue.Enqueue(operatorStack.Pop().ToString());
                    }

                    operatorStack.Push(currentChar);
                    continue;
                }

                stringBuilder.Append(input.SanitizedInput[i]);
            }

            // add the last number to queue
            rpnQueue.Enqueue(stringBuilder.ToString());

            while(operatorStack.Count > 0)
            {
                rpnQueue.Enqueue(operatorStack.Pop().ToString());
            }

            return rpnQueue;
        }
    }
}
