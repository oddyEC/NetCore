using ClaseApiRest.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Contenedor inyeccion

//Si alguien me pide IWeatherService, yo retorno WeatherService

//builder.Services.AddScoped<IWeatherService, WeatherServiceV1<>();
builder.Services.AddScoped<IWeatherService, WeatherServiceV2>();
builder.Services.AddScoped<IRepositoryWeather, RepositoryWeather>();
//builder.Services.AddScoped<IWeatherService, WeatherServiceV3>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
