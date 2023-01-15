// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOddsByGameIdQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetOddsByGameIdQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetOddsByGameIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="GetOddsByGameIdQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{IEnumerable{Odd}}"/>
    public class GetOddsByGameIdQuery : IRequest<IEnumerable<Odd>>
    {
        /// <summary>
        /// Gets the game identifier.
        /// </summary>
        /// <value>The game identifier.</value>
        public Guid GameId { get; init; }
    }
}