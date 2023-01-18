// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCompetitionCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateCompetitionCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateCompetitionCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateCompetitionCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Competition}"/>
    public class UpdateCompetitionCommand : IRequest<Competition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCompetitionCommand"/> class.
        /// </summary>
        public UpdateCompetitionCommand()
        {
            this.Description = string.Empty;
            this.Region = string.Empty;
        }

        /// <summary>
        /// Gets the competition identifier.
        /// </summary>
        /// <value>The competition identifier.</value>
        public Guid CompetitionId { get; init; }

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