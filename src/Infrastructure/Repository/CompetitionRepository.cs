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
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;

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
    }
}