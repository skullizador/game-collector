// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOddBuilder.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IOddBuilder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Builder.OddBuilder
{
    using System;
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="IOddBuilder"/>
    /// </summary>
    public interface IOddBuilder
    {
        /// <summary>
        /// Adds the team identifier.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <returns></returns>
        IOddBuilder AddTeamId(Guid? teamId);

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        Odd Build();

        /// <summary>
        /// Creates new odd.
        /// </summary>
        /// <param name="bookmakerId">The bookmaker identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        IOddBuilder NewOdd(Guid bookmakerId, OddType type, decimal value);
    }
}