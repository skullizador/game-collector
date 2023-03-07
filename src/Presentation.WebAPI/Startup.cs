// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Startup
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI
{
    using System.Reflection;
    using FluentValidation.AspNetCore;
    using GameCollector.Domain.Configuration;
    using GameCollector.Infrastructure;
    using GameCollector.Infrastructure.Configuration;
    using GameCollector.Presentation.WebAPI.Configuration;
    using GameCollector.Presentation.WebAPI.Exceptions.Middleware;
    using GameCollector.Presentation.WebAPI.Validation;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// <see cref="Startup"/>
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configure(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is "Development")
            {
                MigrateDatabase(app);
            }

            app.UseExceptionMiddleware();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Game Collector API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GameCollectorDBContext>(options => options.UseLazyLoadingProxies(), ServiceLifetime.Scoped);

            services.RegisterDomainServices();
            services.RegisterInfrastructureServices();
            services.RegisterPresentationServices();

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidationAttribute));
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Game Collector API",
                });
            });
        }

        /// <summary>
        /// Migrates the database.
        /// </summary>
        /// <param name="app">The application.</param>
        private static void MigrateDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<GameCollectorDBContext>();

            context.Database.MigrateAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}