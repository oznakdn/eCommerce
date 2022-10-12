using eCommerceAPI.Application.ValidationRules.ProductValidators;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace eCommerceAPI.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // Fluent Validation conf.
            services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
