// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByGameIdDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByGameIdDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    /// <summary>
    /// <see cref="GetByGameIdDto"/>
    /// </summary>
    public class GetByGameIdDto
    {
        /// <summary>
        /// Gets the game identifier.
        /// </summary>
        /// <value>The game identifier.</value>
        public Guid GameId { get; init; }
    }
}