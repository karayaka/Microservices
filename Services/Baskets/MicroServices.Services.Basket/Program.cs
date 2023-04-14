using MicroServices.Services.Basket.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.SettingRegistration(builder.Configuration);

builder.Services.ServicesRegistration();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

