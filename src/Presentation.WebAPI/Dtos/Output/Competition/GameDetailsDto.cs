// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameDetailsDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GameDetailsDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Output.Competition
{
    /// <summary>
    /// <see cref="GameDetailsDto"/>
    /// </summary>
    public class GameDetailsDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameDetailsDto"/> class.
        /// </summary>
        public GameDetailsDto()
        {
            this.Odds = new();
            this.Score = string.Empty;
        }

        /// <summary>
        /// Gets the odds.
        /// </summary>
        /// <value>The odds.</value>
        public List<OddDetailsDto> Odds { get; init; }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <value>The score.</value>
        public string Score { get; init; }

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

        /// <summary>
        /// Gets the uu identifier.
        /// </summary>
        /// <value>The uu identifier.</value>
        public Guid UUId { get; init; }
    }
}