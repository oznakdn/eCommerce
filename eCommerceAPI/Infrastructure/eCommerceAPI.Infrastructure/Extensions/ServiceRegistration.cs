using eCommerceAPI.Application.Abstractions.Token;
using eCommerceAPI.Infrastructure.Service.TokenService;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceAPI.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
