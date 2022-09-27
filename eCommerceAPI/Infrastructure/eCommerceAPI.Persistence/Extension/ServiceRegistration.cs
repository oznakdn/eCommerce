using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Application.Repositories.ProductRepo;
using eCommerceAPI.Application.UnitOfWork;
using eCommerceAPI.Persistence.Repositories.CustomerRepo;
using eCommerceAPI.Persistence.Repositories.OrderRepo;
using eCommerceAPI.Persistence.Repositories.ProductRepo;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceAPI.Persistence.Extension
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddContainer(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, eCommerceAPI.Persistence.UnitOfWork.UnitOfWork>();

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            return services;
        }
    }
}
