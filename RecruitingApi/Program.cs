using Microsoft.EntityFrameworkCore;
using RecruitingApi.Data;
using RecruitingApi.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // OpenAPI is industry-standard. It explicity outlines your available endpoints, required parameters, request/response models, and auth methods.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRecruitingEventService, RecruitingEventService>(); // one instance per HTTP request 
builder.Services.AddScoped<IOccupationService, OccupationService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>(); 

var app = builder.Build();

// everything after the DI container is the middleware pipeline
// the steps every request must pas through in order. 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // checking if in dev environment 
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // UI for testing
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
