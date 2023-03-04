// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateOddDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateOddDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="CreateOddDto"/>
    /// </summary>
    public class CreateOddDto
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
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; init; }
    }
}