// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompetitionRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ICompetitionRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Repository
{
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="ICompetitionRepository"/>
    /// </summary>
    /// <seealso cref="IRepository{Competition}"/>
    public interface ICompetitionRepository : IRepository<Competition>
    {
    }
}