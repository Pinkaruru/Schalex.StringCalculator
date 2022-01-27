using Microsoft.Extensions.DependencyInjection;
using Schalex.StringCalculator.Interfaces;
using Schalex.StringCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<IEntryPoint, EntryPoint>();
            services.AddScoped<IConsoleCommunicator, ConsoleCommunicator>();

            return services;
        }
    }
}
