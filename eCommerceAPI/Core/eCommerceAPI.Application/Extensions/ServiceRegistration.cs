using eCommerceAPI.Application.ValidationRules.ProductValidators;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using System.Reflection;
using eCommerceAPI.Application.Abstractions.Token;

namespace eCommerceAPI.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // Fluent Validation conf.
            services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            // MediatR conf.
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
