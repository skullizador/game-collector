// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Odd.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// Odd
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition
{
    using System;
    using System.Collections.Generic;
    using GameCollector.Domain.AggregateModels.Competition.Enum;
    using GameCollector.Domain.Exceptions;
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="Odd"/>
    /// </summary>
    /// <seealso cref="EntityBase"/>
    public class Odd : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Odd"/> class.
        /// </summary>
        /// <param name="bookmakerId">The bookmaker identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        internal Odd(Guid bookmakerId, OddType type, decimal value)
        {
            this.BookmakerId = bookmakerId;
            this.Type = type;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Odd"/> class.
        /// </summary>
        protected Odd()
        {
        }

        /// <summary>
        /// Gets the bookmaker identifier.
        /// </summary>
        /// <value>The bookmaker identifier.</value>
        public Guid BookmakerId { get; private set; }

        /// <summary>
        /// Gets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        public Guid? TeamId { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public OddType Type { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; private set; }

        /// <summary>
        /// Sets the team identifier.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <exception cref="InvalidOddException">
        /// The odd type X shouldn't be related to a team.
        /// </exception>
        internal void SetTeamId(Guid? teamId)
        {
            if (this.Type is OddType.X && this.TeamId.HasValue)
            {
                throw new InvalidOddException("The odd type X shouldn't be related to a team.");
            }

            this.TeamId = teamId;
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