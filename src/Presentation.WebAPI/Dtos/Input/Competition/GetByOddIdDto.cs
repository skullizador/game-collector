// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByOddIdDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByOddIdDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    /// <summary>
    /// <see cref="GetByOddIdDto"/>
    /// </summary>
    public class GetByOddIdDto
    {
        /// <summary>
        /// Gets the odd identifier.
        /// </summary>
        /// <value>The odd identifier.</value>
        public Guid OddId { get; init; }
    }
}