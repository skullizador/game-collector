// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompetitionBuilder.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ICompetitionBuilder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Builder.CompetitionBuilder
{
    using System.Collections.Generic;
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="ICompetitionBuilder"/>
    /// </summary>
    public interface ICompetitionBuilder
    {
        /// <summary>
        /// Adds the games.
        /// </summary>
        /// <param name="games">The games.</param>
        /// <returns></returns>
        ICompetitionBuilder AddGames(List<Game> games);

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        Competition Build();

        /// <summary>
        /// Creates new competition.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="year">The year.</param>
        /// <param name="region">The region.</param>
        /// <param name="description">The description.</param>
        /// <param name="sports">The sports.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        ICompetitionBuilder NewCompetition(string name, int year, string region, string description, SportsType sports, CompetitionType type);
    }
}