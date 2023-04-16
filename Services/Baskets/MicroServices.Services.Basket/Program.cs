using Microservice.Shared.Registrations;
using MicroServices.Services.Basket.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.SettingRegistration(builder.Configuration);

builder.Services.ServicesRegistration();

builder.Services.AddControllers();

builder.Services.AddJWTAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

