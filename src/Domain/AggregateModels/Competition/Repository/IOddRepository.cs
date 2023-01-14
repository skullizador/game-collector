// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOddRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IOddRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Repository
{
    using GameCollector.Domain.SeedWork;

    /// <summary>
    /// <see cref="IOddRepository"/>
    /// </summary>
    /// <seealso cref="IRepository{Odd}"/>
    public interface IOddRepository : IRepository<Odd>
    {
    }
}