// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByOddIdQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByOddIdQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetByOddIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="GetByOddIdQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{Odd}"/>
    public class GetByOddIdQuery : IRequest<Odd>
    {
        /// <summary>
        /// Gets the odd identifier.
        /// </summary>
        /// <value>The odd identifier.</value>
        public Guid OddId { get; init; }
    }
}