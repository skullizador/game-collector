// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionBuilder.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionBuilder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Builder.CompetitionBuilder
{
    using System.Collections.Generic;
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="CompetitionBuilder"/>
    /// </summary>
    /// <seealso cref="ICompetitionBuilder"/>
    internal class CompetitionBuilder : ICompetitionBuilder
    {
        /// <summary>
        /// The competition
        /// </summary>
        private Competition competition;

        /// <summary>
        /// Adds the games.
        /// </summary>
        /// <param name="games">The games.</param>
        /// <returns></returns>
        public ICompetitionBuilder AddGames(List<Game> games)
        {
            foreach (Game game in games)
            {
                this.competition.AddGame(game);
            }

            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Competition Build()
        {
            return this.competition;
        }

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
        public ICompetitionBuilder NewCompetition(string name, int year, string region, string description, SportsType sports, CompetitionType type)
        {
            this.competition = new(name, year, region, description, sports, type);

            return this;
        }
    }
}