﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using DotNETTask.Infrastructure.Middleware;
using DotNETTask.Persistence.Context;
using DotNETTask.Persistence.Interfaces.Repositories;
using DotNETTask.Settings;

namespace DotNETTask.Infrastructure
{
    public static class ConfigureServiceContainer
    {

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/DotNetTaskAPISpecification/swagger.json", "DotNetTask APIs");
                setupAction.RoutePrefix = "Swagger";
            });
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void AddHealthCheck(this IServiceCollection serviceCollection, AppSettings appSettings, IConfiguration configuration)
        {
            //serviceCollection.AddHealthChecks()
            //    .AddDbContextCheck<AppDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded);

            //serviceCollection.AddHealthChecksUI(setupSettings: setup =>
            //{
            //    setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
            //}).AddInMemoryStorage();
        }


        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "DotNetTaskAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "DotNet Task  APIs",
                        Version = "1",
                        Description = "Through this API you can access all the available apis",
                        Contact = new OpenApiContact()
                        {
                            Email = "tadese.teejay@gmail.com",
                            Name = "Tajudeen Yusuf",
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

        }
    }
}
