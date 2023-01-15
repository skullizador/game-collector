// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetGamesByCompetitionIdQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetGamesByCompetitionIdQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetGamesByCompetitionIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="GetGamesByCompetitionIdQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{IEnumerable{Game}}"/>
    public class GetGamesByCompetitionIdQuery : IRequest<IEnumerable<Game>>
    {
        /// <summary>
        /// Gets the competition identifier.
        /// </summary>
        /// <value>The competition identifier.</value>
        public Guid CompetitionId { get; init; }
    }
}