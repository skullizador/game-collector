// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByCompetitionIdQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByCompetitionIdQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetByCompetitionIdQuery
{
    using Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="GetByCompetitionIdQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{Competition}"/>
    public class GetByCompetitionIdQuery : IRequest<Competition>
    {
        /// <summary>
        /// Gets the competition identifier.
        /// </summary>
        /// <value>The competition identifier.</value>
        public Guid CompetitionId { get; init; }
    }
}