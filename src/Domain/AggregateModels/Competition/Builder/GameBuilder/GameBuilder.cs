// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameBuilder.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GameBuilder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Builder.GameBuilder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="GameBuilder"/>
    /// </summary>
    /// <seealso cref="IGameBuilder"/>
    internal class GameBuilder : IGameBuilder
    {
        /// <summary>
        /// The game
        /// </summary>
        private Game game;

        /// <summary>
        /// Adds the odds.
        /// </summary>
        /// <param name="odds">The odds.</param>
        /// <returns></returns>
        public IGameBuilder AddOdds(List<Odd> odds)
        {
            foreach (var odd in odds)
            {
                this.game.AddOdd(odd);
            }

            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Game Build()
        {
            return this.game;
        }

        /// <summary>
        /// Creates new game.
        /// </summary>
        /// <param name="teamAId">The team a identifier.</param>
        /// <param name="teamBId">The team b identifier.</param>
        /// <param name="Score">The score.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns></returns>
        public IGameBuilder NewGame(Guid teamAId, Guid teamBId, string Score, DateTime startDate)
        {
            this.game = new Game(teamAId, teamBId, Score, startDate);

            return this;
        }
    }
}