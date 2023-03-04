// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGameBuilder.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IGameBuilder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Builder.GameBuilder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="IGameBuilder"/>
    /// </summary>
    public interface IGameBuilder
    {
        /// <summary>
        /// Adds the odds.
        /// </summary>
        /// <param name="odds">The odds.</param>
        /// <returns></returns>
        IGameBuilder AddOdds(List<Odd> odds);

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        Game Build();

        /// <summary>
        /// Creates new game.
        /// </summary>
        /// <param name="teamAId">The team a identifier.</param>
        /// <param name="teamBId">The team b identifier.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns></returns>
        IGameBuilder NewGame(Guid teamAId, Guid teamBId, DateTime startDate);
    }
}