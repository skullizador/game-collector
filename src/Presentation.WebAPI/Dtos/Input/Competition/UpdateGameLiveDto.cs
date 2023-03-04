// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameLiveDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameLiveDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    /// <summary>
    /// <see cref="UpdateGameLiveDto"/>
    /// </summary>
    public class UpdateGameLiveDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGameLiveDto"/> class.
        /// </summary>
        public UpdateGameLiveDto()
        {
            this.Score = string.Empty;
        }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <value>The score.</value>
        public string Score { get; init; }
    }
}