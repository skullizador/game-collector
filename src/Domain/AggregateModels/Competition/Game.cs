// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Game.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Game
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameCollector.Domain.Exceptions;
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="Game"/>
    /// </summary>
    /// <seealso cref="EntityBase"/>
    public class Game : EntityBase
    {
        /// <summary>
        /// The odds
        /// </summary>
        private readonly List<Odd> odds;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="teamAId">The team a identifier.</param>
        /// <param name="teamBId">The team b identifier.</param>
        /// <param name="score">The score.</param>
        /// <param name="startDate">The start date.</param>
        internal Game(Guid teamAId, Guid teamBId, string score, DateTime startDate)
            : this()
        {
            this.TeamAId = teamAId;
            this.TeamBId = teamBId;
            this.Score = score;
            this.StartDate = startDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        protected Game()
        {
            this.odds = new List<Odd>();
        }

        /// <summary>
        /// Gets the odds.
        /// </summary>
        /// <value>The odds.</value>
        public virtual IReadOnlyCollection<Odd> Odds => this.odds;

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <value>The score.</value>
        public string Score { get; private set; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Gets the team a identifier.
        /// </summary>
        /// <value>The team a identifier.</value>
        public Guid TeamAId { get; private set; }

        /// <summary>
        /// Gets the team b identifier.
        /// </summary>
        /// <value>The team b identifier.</value>
        public Guid TeamBId { get; private set; }

        /// <summary>
        /// Adds the odd.
        /// </summary>
        /// <param name="odd">The odd.</param>
        /// <exception cref="ArgumentNullException">odd - The Odd is null.</exception>
        /// <exception cref="DuplicatedException">
        /// The Odd on position {odd.Type} for bookmaker {odd.BookmakerId} already exists in game {this.UUId}.
        /// </exception>
        public void AddOdd(Odd odd)
        {
            if (odd is null)
            {
                throw new ArgumentNullException(nameof(odd), "The Odd is null.");
            }

            if (this.odds.Any(x => x.BookmakerId == odd.BookmakerId && x.Type == odd.Type))
            {
                throw new DuplicatedException($"The Odd on position {odd.Type} for bookmaker {odd.BookmakerId} already exists in game {this.UUId}.");
            }

            this.odds.Add(odd);
        }

        /// <summary>
        /// Updates the specified score.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="teamAId">The team a identifier.</param>
        /// <param name="teamBId">The team b identifier.</param>
        public void Update(DateTime startDate, Guid teamAId, Guid teamBId)
        {
            if(DateTime.Now >= this.StartDate)
            {
                throw new NotUpdatableException($"The Game {this.UUId} that started at {this.StartDate} is no longer updatable.");
            }

            this.StartDate = startDate;
            this.TeamAId = teamAId;
            this.TeamBId= teamBId;
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