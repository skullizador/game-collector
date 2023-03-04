// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateGameCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateGameCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.CreateGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="CreateGameCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Game}"/>
    public class CreateGameCommand : IRequest<Game>
    {
        /// <summary>
        /// Gets the competition identifier.
        /// </summary>
        /// <value>The competition identifier.</value>
        public Guid CompetitionId { get; init; }

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