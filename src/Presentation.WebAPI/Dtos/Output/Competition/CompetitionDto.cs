// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Output.Competition
{
    /// <summary>
    /// <see cref="CompetitionDto"/>
    /// </summary>
    public class CompetitionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionDto"/> class.
        /// </summary>
        public CompetitionDto()
        {
            this.Name = string.Empty;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; init; }

        /// <summary>
        /// Gets the uu identifier.
        /// </summary>
        /// <value>The uu identifier.</value>
        public Guid UUId { get; init; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get; init; }
    }
}