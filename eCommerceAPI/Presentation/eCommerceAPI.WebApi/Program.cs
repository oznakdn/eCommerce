using eCommerceAPI.Application.Extensions;
using eCommerceAPI.Infrastructure.ExceptionHandling;
using eCommerceAPI.Infrastructure.Extensions;
using eCommerceAPI.Infrastructure.Filters;
using eCommerceAPI.Persistence.Extension;
using eCommerceAPI.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();

}).ConfigureApiBehaviorOptions(options =>options.SuppressModelStateInvalidFilter = true);

builder.Services.AddPresentationService(builder.Configuration);
builder.Services.AddPersistenceService();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandling>();

app.Run();
