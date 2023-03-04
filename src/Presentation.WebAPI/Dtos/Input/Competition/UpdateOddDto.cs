// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateOddDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateOddDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    /// <summary>
    /// <see cref="UpdateOddDto"/>
    /// </summary>
    public class UpdateOddDto
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; init; }
    }
}