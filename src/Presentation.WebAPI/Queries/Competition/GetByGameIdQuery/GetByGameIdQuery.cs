// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByGameIdQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByGameIdQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetByGameIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="GetByGameIdQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{Game}"/>
    public class GetByGameIdQuery : IRequest<Game>
    {
        /// <summary>
        /// Gets the game identifier.
        /// </summary>
        /// <value>The game identifier.</value>
        public Guid GameId { get; init; }
    }
}