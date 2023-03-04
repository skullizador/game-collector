// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    /// <summary>
    /// <see cref="UpdateGameDto"/>
    /// </summary>
    public class UpdateGameDto
    {
        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; init; }

        /// <summary>
        /// Gets the team a identifier.
        /// </summary>
        /// <value>The team a identifier.</value>
        public Guid TeamAId { get; init; }

        /// <summary>
        /// Gets the team b identifier.
        /// </summary>
        /// <value>The team b identifier.</value>
        public Guid TeamBId { get; init; }
    }
}