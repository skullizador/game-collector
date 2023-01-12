// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Program
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GameCollector.Presentation.WebAPI;
using Serilog;
using Steeltoe.Extensions.Configuration.ConfigServer;

WebApplicationBuilder builder = CreateBuilder(args);

Startup startup = new(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app);

app.Run();

static WebApplicationBuilder CreateBuilder(string[] args)
{
    var webApplicationOptions = new WebApplicationOptions
    {
        Args = args,
        ContentRootPath = $"{Directory.GetCurrentDirectory()}/Configuration"
    };

    var builder = WebApplication.CreateBuilder(webApplicationOptions);

    builder.Host.ConfigureAppConfiguration((builderContext, config) =>
    {
        var hostingEnvironment = builderContext.HostingEnvironment;
        config.AddConfigServer(hostingEnvironment.EnvironmentName);
        config.AddEnvironmentVariables();
    })
    .UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
    });

    return builder;
}