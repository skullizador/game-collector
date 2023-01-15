// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OddDetailsDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// OddDetailsDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Output.Competition
{
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="OddDetailsDto"/>
    /// </summary>
    public class OddDetailsDto
    {
        /// <summary>
        /// Gets the bookmaker identifier.
        /// </summary>
        /// <value>The bookmaker identifier.</value>
        public Guid BookmakerId { get; init; }

        /// <summary>
        /// Gets the type of the odd.
        /// </summary>
        /// <value>The type of the odd.</value>
        public OddType OddType { get; init; }

        /// <summary>
        /// Gets the uu identifier.
        /// </summary>
        /// <value>The uu identifier.</value>
        public Guid UUId { get; init; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; init; }
    }
}