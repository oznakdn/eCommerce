using eCommerceAPI.Application.Extensions;
using eCommerceAPI.Infrastructure.ExceptionHandling;
using eCommerceAPI.Infrastructure.Extensions;
using eCommerceAPI.Infrastructure.Filters;
using eCommerceAPI.Persistence.Extension;
using eCommerceAPI.WebApi.Extensions;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();

}).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);


// Serilog conf.
Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt",
          rollingInterval: RollingInterval.Day,
          outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.SQLite("C:/Users/USER/Desktop/eCommerce/eCommerceAPI/Presentation/eCommerceAPI.WebApi/logs/LogsDb.db", "Logs")
    .CreateLogger();

builder.Host.UseSerilog(log);

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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("defaultCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandling>();

app.Run();
