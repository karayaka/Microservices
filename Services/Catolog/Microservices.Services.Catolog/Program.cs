using Microservice.Shared.Registrations;
using Microservices.Services.Catolog.Rgistrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.MapperRegistration();

builder.Services.RabitMqRegistration(builder.Configuration);

//token resolver!
builder.Services.AddJWTAuthentication(builder.Configuration);

builder.Services.Config(builder.Configuration);

builder.Services.ServicesRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
