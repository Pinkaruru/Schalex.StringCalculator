using Microsoft.Extensions.DependencyInjection;
using Schalex.StringCalculator.Core.Interfaces;
using Schalex.StringCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalex.StringCalculator.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IInputValidator, InputValidator>();
            services.AddScoped<IInputSanitizer, InputSanitizer>();
            services.AddScoped<ICalculator, Calculator>();

            return services;
        }
    }
}
