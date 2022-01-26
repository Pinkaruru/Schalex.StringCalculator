using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Interfaces;

namespace Schalex.StringCalculator.Services
{
    public class EntryPoint : IEntryPoint
    {
        private readonly IInputValidator validator;

        public EntryPoint(IInputValidator validator)
        {
            this.validator = validator;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Maersk StringCalculator!");
            Console.WriteLine("This calculator only supports !");
            throw new NotImplementedException();
        }
    }
}
