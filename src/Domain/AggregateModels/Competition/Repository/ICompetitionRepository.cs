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
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition.Enum;
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="ICompetitionRepository"/>
    /// </summary>
    /// <seealso cref="IRepository{Competition}"/>
    public interface ICompetitionRepository : IRepository<Competition>
    {
        /// <summary>
        /// Gets the unique asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="region">The region.</param>
        /// <param name="year">The year.</param>
        /// <param name="type">The type.</param>
        /// <param name="sport">The sport.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Competition> GetUniqueAsync(string name, string region, int year, CompetitionType type, SportsType sport, CancellationToken cancellationToken);
    }
}