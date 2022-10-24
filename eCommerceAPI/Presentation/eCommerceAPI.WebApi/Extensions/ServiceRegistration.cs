using eCommerceAPI.Domain.Entities.Identity;
using eCommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            // Jwt configuration
            services.AddAuthentication("Admin").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = configuration["JwtToken:Audience"],
                    ValidIssuer = configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:SecurityKey"])),
                    LifetimeValidator = (notBefore, expires, securityToken, validateParameters) => expires != null ? expires > DateTime.UtcNow : false
                };
            });


        }


    }
}
