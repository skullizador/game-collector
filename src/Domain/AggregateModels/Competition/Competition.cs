// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Competition.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Competition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameCollector.Domain.AggregateModels.Competition.Enum;
    using GameCollector.Domain.Exceptions;
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="Competition"/>
    /// </summary>
    /// <seealso cref="EntityBase"/>
    /// <seealso cref="IAggregateRoot"/>
    public class Competition : EntityBase, IAggregateRoot
    {
        /// <summary>
        /// The games
        /// </summary>
        private readonly List<Game> games;

        /// <summary>
        /// Initializes a new instance of the <see cref="Competition"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="year">The year.</param>
        /// <param name="region">The region.</param>
        /// <param name="description">The description.</param>
        /// <param name="sports">The sports.</param>
        /// <param name="type">The type.</param>
        internal Competition(string name, int year, string region, string description, SportsType sports, CompetitionType type)
            : this()
        {
            this.Sport = sports;
            this.Name = name;
            this.Year = year;
            this.Region = region;
            this.Description = description;
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Competition"/> class.
        /// </summary>
        protected Competition()
        {
            this.games = new List<Game>();
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the games.
        /// </summary>
        /// <value>The games.</value>
        public virtual IReadOnlyCollection<Game> Games => this.games;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region { get; private set; }

        /// <summary>
        /// Gets the sport.
        /// </summary>
        /// <value>The sport.</value>
        public SportsType Sport { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public CompetitionType Type { get; private set; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get; private set; }

        /// <summary>
        /// Adds the game.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <exception cref="ArgumentNullException">game - The Game is null.</exception>
        /// <exception cref="DuplicatedException">
        /// The Game {game.TeamAId} vs {game.TeamBId} at {game.StartDate} already exists in
        /// competition {this.UUId}.
        /// </exception>
        public void AddGame(Game game)
        {
            if (game is null)
            {
                throw new ArgumentNullException(nameof(game), "The Game is null.");
            }

            if (this.games.Any(x => x.TeamAId == game.TeamAId && x.TeamBId == game.TeamBId && x.StartDate == game.StartDate))
            {
                throw new DuplicatedException($"The Game {game.TeamAId} vs {game.TeamBId} at {game.StartDate} already exists in competition {this.UUId}.");
            }

            this.games.Add(game);
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.UUId;
        }
    }
}