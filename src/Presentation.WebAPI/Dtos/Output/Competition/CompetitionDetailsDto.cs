// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionDetailsDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionDetailsDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Output.Competition
{
    using GameCollector.Domain.AggregateModels.Competition.Enum;

    /// <summary>
    /// <see cref="CompetitionDetailsDto"/>
    /// </summary>
    public class CompetitionDetailsDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionDetailsDto"/> class.
        /// </summary>
        public CompetitionDetailsDto()
        {
            this.Games = new();
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
        /// Gets the games.
        /// </summary>
        /// <value>The games.</value>
        public List<GameDetailsDto> Games { get; init; }

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
        /// Gets the sports.
        /// </summary>
        /// <value>The sports.</value>
        public SportsType Sports { get; init; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public CompetitionType Type { get; init; }

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