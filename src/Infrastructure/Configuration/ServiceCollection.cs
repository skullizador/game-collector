// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollection.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ServiceCollection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.Configuration
{
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Infrastructure.Repository;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="ServiceCollection"/>
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Registers the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IOddRepository, OddRepository>();

            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
        }
    }
}