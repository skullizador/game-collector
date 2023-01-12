// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.SeedWork
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// <see cref="IRepository"/>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token);

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task AddRangeAsync(TEntity[] entity, CancellationToken token);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid uuid, CancellationToken token);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<bool> Remove(TEntity entity, CancellationToken token);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity entity, CancellationToken token);
    }
}