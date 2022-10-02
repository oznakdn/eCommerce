using eCommerceAPI.Domain.Entities.Identity;
using eCommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eCommerceAPI.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPresentationService(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext conf.
            services.AddDbContext<eCommerceDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("eCommerceConnectionString")));

            // Identity conf.
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<eCommerceDbContext>();

            // Cors conf.
            services.AddCors(option => option.AddPolicy("defaultCors", policy =>
            {
                policy.WithOrigins("http://localhost:4200", "https://localhost:4200");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }));
        }

      
    }
}
