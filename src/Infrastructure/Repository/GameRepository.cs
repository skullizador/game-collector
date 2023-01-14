// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GameRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.Repository
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;

    /// <summary>
    /// <see cref="GameRepository"/>
    /// </summary>
    /// <seealso cref="GenericRepository{Game}"/>
    /// <seealso cref="IGameRepository"/>
    internal class GameRepository : GenericRepository<Game>, IGameRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GameRepository(GameCollectorDBContext context)
            : base(context)
        {
        }
    }
}