// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OddRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// OddRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.Repository
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;

    /// <summary>
    /// <see cref="OddRepository"/>
    /// </summary>
    /// <seealso cref="GenericRepository{Odd}"/>
    /// <seealso cref="IOddRepository"/>
    internal class OddRepository : GenericRepository<Odd>, IOddRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OddRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public OddRepository(GameCollectorDBContext context)
            : base(context)
        {
        }
    }
}