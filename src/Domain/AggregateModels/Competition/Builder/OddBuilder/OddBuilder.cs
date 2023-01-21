// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OddBuilder.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// OddBuilder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Builder.OddBuilder
{
    using System;
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="OddBuilder"/>
    /// </summary>
    /// <seealso cref="IOddBuilder"/>
    internal class OddBuilder : IOddBuilder
    {
        /// <summary>
        /// The odd
        /// </summary>
        private Odd odd;

        /// <summary>
        /// Adds the team identifier.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        public IOddBuilder AddTeamId(Guid? teamId)
        {
            if(teamId is not null)
            {
                this.odd.SetTeamId(teamId);
            }

            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Odd Build()
        {
            return this.odd;
        }

        /// <summary>
        /// Creates new odd.
        /// </summary>
        /// <param name="bookmakerId">The bookmaker identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public IOddBuilder NewOdd(Guid bookmakerId, OddType type, decimal value)
        {
            this.odd = new Odd(bookmakerId, type, value);

            return this;
        }
    }
}