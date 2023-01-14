// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollection.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ServiceCollection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.Configuration
{
    using GameCollector.Domain.AggregateModels.Competition.Builder.CompetitionBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Builder.GameBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Builder.OddBuilder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="ServiceCollection"/>
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Registers the domain services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOddBuilder, OddBuilder>();

            services.AddScoped<IGameBuilder, GameBuilder>();

            services.AddScoped<ICompetitionBuilder, CompetitionBuilder>();
        }
    }
}