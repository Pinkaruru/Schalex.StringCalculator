using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schalex.StringCalculator.Core;
using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Interfaces;
using Schalex.StringCalculator.Services;

namespace Schalex.StringCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var application = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddApplication();
                    services.AddPresentation();
                })
                .Build();

            var entryPoint = application.Services.GetService<IEntryPoint>() ?? throw new ArgumentNullException("Unable to find entrypoint for StringCalculator");
            entryPoint.Run();
        }
    }
}