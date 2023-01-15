// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllCompetitionsQuery.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetAllCompetitionsQuery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetAllCompetitionsQuery
{
    using Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="GetAllCompetitionsQuery"/>
    /// </summary>
    /// <seealso cref="IRequest{IEnumerable{Competition}}"/>
    public class GetAllCompetitionsQuery : IRequest<IEnumerable<Competition>>
    {
    }
}