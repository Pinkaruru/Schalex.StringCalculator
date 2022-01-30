using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Domain;
using Schalex.StringCalculator.Domain.Exceptions;
using Schalex.StringCalculator.Interfaces;

namespace Schalex.StringCalculator.Services
{
    public class EntryPoint : IEntryPoint
    {
        private readonly IConsoleCommunicator communicator;
        private readonly ICalculator calculator;

        public EntryPoint(IConsoleCommunicator communicator,
            ICalculator calculator)
        {
            this.communicator = communicator ?? throw new ArgumentNullException(nameof(communicator));
            this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Run()
        {
            communicator.PrintGreeting();
            string? input = communicator.GetInput();

            while (input != "q")
            {
                try
                {
                    var stringInput = new StringInput(input);
                    var result = calculator.Calculate(stringInput);
                    communicator.PrintResult(stringInput, result);

                    input = communicator.GetInput();
                }
                catch (StringCalculatorException e)
                {
                    communicator.PrintErrorMessage(e);
                }
            }
        }
    }
}
