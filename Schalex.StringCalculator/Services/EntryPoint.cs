using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Interfaces;

namespace Schalex.StringCalculator.Services
{
    public class EntryPoint : IEntryPoint
    {
        private readonly IConsoleCommunicator communicator;

        public EntryPoint(IConsoleCommunicator communicator)
        {
            this.communicator = communicator;
        }

        public void Run()
        {
            communicator.PrintGreeting();
            string? input = null;

            while(input != "q")
            {
                input = communicator.GetInput();
            }
        }
    }
}
