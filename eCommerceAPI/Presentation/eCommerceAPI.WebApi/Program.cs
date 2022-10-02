using eCommerceAPI.Application.Extensions;
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
