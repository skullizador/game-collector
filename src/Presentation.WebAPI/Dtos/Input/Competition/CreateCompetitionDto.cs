// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCompetitionDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateCompetitionDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="CreateCompetitionDto"/>
    /// </summary>
    public class CreateCompetitionDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompetitionDto"/> class.
        /// </summary>
        public CreateCompetitionDto()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Region = string.Empty;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; init; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; init; }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region { get; init; }

        /// <summary>
        /// Gets the sport.
        /// </summary>
        /// <value>The sport.</value>
        public SportsType Sport { get; init; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public CompetitionType Type { get; init; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get; init; }
    }
}