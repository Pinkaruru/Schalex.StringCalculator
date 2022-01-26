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
    internal static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddTransient<IEntryPoint, EntryPoint>();

            return services;
        }
    }
}
