// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCompetitionCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateCompetitionCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.CreateCompetitionCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Enum;
    using MediatR;

    /// <summary>
    /// <see cref="CreateCompetitionCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Competition}"/>
    public class CreateCompetitionCommand : IRequest<Competition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompetitionCommand"/> class.
        /// </summary>
        public CreateCompetitionCommand()
        {
            Description = string.Empty;
            Name = string.Empty;
            Region = string.Empty;
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