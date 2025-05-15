using Investments.Application.Services;
using Investments.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Investments.Application
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICdbService, CdbService>();
            services.AddScoped<IFinanceService, FinanceService>();

            return services;
        }
    }
}
