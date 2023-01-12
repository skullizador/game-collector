// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGameRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IGameRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Repository
{
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="IGameRepository"/>
    /// </summary>
    /// <seealso cref="IRepository{Game}"/>
    public interface IGameRepository : IRepository<Game>
    {
    }
}