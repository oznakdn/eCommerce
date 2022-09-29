using eCommerceAPI.Domain.Entities.Identity;
using eCommerceAPI.Persistence.Contexts;
using eCommerceAPI.Persistence.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<eCommerceDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("eCommerceConnectionString")));
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireLowercase= true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireDigit = true;
}).AddEntityFrameworkStores<eCommerceDbContext>();

builder.Services.AddPersistenceContainer();

builder.Services.AddCors(option => option.AddPolicy("defaultCors", policy =>
{
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200");
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("defaultCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
