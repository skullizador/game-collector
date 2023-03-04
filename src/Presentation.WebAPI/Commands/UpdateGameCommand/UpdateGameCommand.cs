// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateGameCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Game}"/>
    public class UpdateGameCommand : IRequest<Game>
    {
        /// <summary>
        /// Gets the game identifier.
        /// </summary>
        /// <value>The game identifier.</value>
        public Guid GameId { get; init; }

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