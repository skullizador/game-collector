// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCompetitionDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateCompetitionDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    /// <summary>
    /// <see cref="UpdateCompetitionDto"/>
    /// </summary>
    public class UpdateCompetitionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCompetitionDto"/> class.
        /// </summary>
        public UpdateCompetitionDto()
        {
            this.Description = string.Empty;
            this.Region = string.Empty;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; init; }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region { get; init; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get; init; }
    }
}