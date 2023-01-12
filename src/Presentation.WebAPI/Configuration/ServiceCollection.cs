// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollection.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ServiceCollection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="ServiceCollection"/>
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Registers the presentation services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterPresentationServices(this IServiceCollection services)
        {
        }
    }
}