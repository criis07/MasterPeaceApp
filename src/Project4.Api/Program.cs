using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Project4.Api.Services;
using Project4.Application;
using Project4.Application.Interfaces.Persistence;
using Project4.Application.Interfaces.Services;
using Project4.Infrastructure.Persistence;
using Project4.Infrastructure.Services;
using Project4.Infrastructure.Persistence.DataServices.MarcasAutoService;
using Project4.Application.Interfaces.Persistence.DataServices.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Project4.Application.Interfaces.Persistence.DataServices.User;
using Project4.Infrastructure.Persistence.DataServices.UserService;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Infrastructure.Persistence.DataServices.CatalogService;
using Project4.Application.Interfaces.Persistence.DataServices.Batch;
using Project4.Infrastructure.Persistence.DataServices.BatchService;

public class Program
{
    public static void Main(string[] args)
    {
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

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))

            };
        });

        builder.Services.AddScoped<IUserService, UserService>();

        //DB entities
        builder.Services.AddScoped<ICatalogService, CatalogService>();
        builder.Services.AddScoped<IBatchService, BatchService>();

        // Agregar la interfaz y la implementación del contexto de la aplicación
        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        // Inyectamos dependencias por medio de program.cs
        builder.Services.AddScoped<IPrincipalService, PrincipalService>();
        builder.Services.AddScoped<IMarcasAutosService, MarcasAutosService>();
        builder.Services.AddScoped<IDateTimeService, DateTimeService>();





        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project4.Api", Version = "v1" });
        });

        builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project4.Api v1"));
        }
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project4.Api v1"));

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHealthChecks("/health");
        app.MapControllers();

        app.MapGet("/", () => "Hello from AWS Lambda!, primer release TEST");
        // Ejecutar la aplicación
        app.Run();
    }

    // Método Configure necesario para que las pruebas funcionen correctamente
    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
