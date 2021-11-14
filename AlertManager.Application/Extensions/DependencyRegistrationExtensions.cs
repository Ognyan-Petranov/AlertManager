using AlertManager.Application.Features.ValidationService;
using AlertManager.Application.Interfaces;
using AlertManager.Application.Services.FakeApiService;
using Microsoft.Extensions.DependencyInjection;

namespace AlertManager.Application.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterValidationService(this IServiceCollection services)
        {
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<IFakeApiService, FakeApiService>();

            return services;
        }
    }
}
