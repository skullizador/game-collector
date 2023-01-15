// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OddDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// OddDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Output.Competition
{
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="OddDto"/>
    /// </summary>
    public class OddDto
    {
        /// <summary>
        /// Gets the bookmaker identifier.
        /// </summary>
        /// <value>The bookmaker identifier.</value>
        public Guid BookmakerId { get; init; }

        /// <summary>
        /// Gets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        public Guid? TeamId { get; init; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public OddType Type { get; init; }

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