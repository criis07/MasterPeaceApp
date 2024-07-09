using Project4.Api.Services;
using Project4.Application;
using Project4.Application.Interfaces.Services;
using Project4.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Project4.Application.Interfaces.Persistence.DataServices.Users.Queries;
using Project4.Infrastructure.Persistence.DataServices.MarcasAutoService;
using Microsoft.EntityFrameworkCore;
using Project4.Application.Interfaces.Persistence;
using Project4.Infrastructure.Persistence;
using Project4.Infrastructure.Services;

// Configure Services
var builder = WebApplication.CreateBuilder(args);
// TODO: Remove this line if you want to return the Server header
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

builder.Services.AddSingleton(builder.Configuration);

// Adds in Application dependencies
builder.Services.AddApplication(builder.Configuration);
// Adds in Infrastructure dependencies
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();

// Agregar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar la interfaz y la implementación del contexto de la aplicación
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
});

//Inyectamos dependencias por medio de program.cs
builder.Services.AddScoped<IPrincipalService, PrincipalService>();

builder.Services.AddScoped<IMarcasAutosService, MarcasAutosService>();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();



builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project4.Api", Version = "v1" });
});

// Configure Application
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project4.Api v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.Use(async (httpContext, next) =>
{
    var apiMode = httpContext.Request.Path.StartsWithSegments("/api");
    if (apiMode)
    {
        httpContext.Request.Headers[HeaderNames.XRequestedWith] = "XMLHttpRequest";
    }
    await next();
});

app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
