using FluentValidation;
using Investments.Domain.Dtos.Requests;
using Investments.WebApi.Validators.SimulateInvestment;
using System.Diagnostics.CodeAnalysis;

namespace Investments.WebApi
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<SimulateCdbRequestDto>, SimulateCdbValidator>();

            return services;
        }
    }
}
