using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schalex.StringCalculator.Core;
using Schalex.StringCalculator.Interfaces;

namespace Schalex.StringCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddApplication();
                    services.AddPresentation();
                })
                .Build();

            var entryPoint = ActivatorUtilities.CreateInstance<IEntryPoint>(host.Services);
            entryPoint.Run();
        }
    }
}