// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Enum;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <see cref="CompetitionRepository"/>
    /// </summary>
    /// <seealso cref="GenericRepository{Competition}"/>
    /// <seealso cref="ICompetitionRepository"/>
    internal class CompetitionRepository : GenericRepository<Competition>, ICompetitionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CompetitionRepository(GameCollectorDBContext context)
            : base(context)
        {
        }

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
        public async Task<Competition> GetUniqueAsync(
            string name,
            string region,
            int year,
            CompetitionType type,
            SportsType sport,
            CancellationToken cancellationToken)
        {
            return await this.Entities.SingleOrDefaultAsync(x =>
                x.Name == name &&
                x.Region == region &&
                x.Year == year &&
                x.Type == type &&
                x.Sport == sport, cancellationToken);
        }
    }
}