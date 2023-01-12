// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericRepository.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GenericRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.SeedWork;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <see cref="GenericRepository"/>
    /// </summary>
    /// <typeparam name="Entity">The type of the ntity.</typeparam>
    /// <seealso cref="IRepository{Entity}"/>
    public class GenericRepository<Entity> : IRepository<Entity>
        where Entity : EntityBase
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly GameCollectorDBContext Context;

        /// <summary>
        /// The entities
        /// </summary>
        protected readonly DbSet<Entity> Entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{Entity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(GameCollectorDBContext context)
        {
            this.Context = context;

            this.Entities = context.Set<Entity>();
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IUnitOfWork UnitOfWork => this.Context;

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<Entity> AddAsync(Entity entity, CancellationToken token)
        {
            var entityEntry = await this.Entities.AddAsync(entity, token);

            return entityEntry.Entity;
        }

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        public async Task AddRangeAsync(Entity[] entity, CancellationToken token)
        {
            await this.Entities.AddRangeAsync(entity);
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<List<Entity>> GetAllAsync(CancellationToken token)
        {
            return await this.Entities.ToListAsync(token);
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<Entity> GetAsync(Guid uuid, CancellationToken token)
        {
            return await this.Entities.FirstOrDefaultAsync(e => e.UUId == uuid, token);
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<bool> Remove(Entity entity, CancellationToken token)
        {
            await Task.FromResult(this.Entities.Remove(entity));

            return true;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<Entity> Update(Entity entity, CancellationToken token)
        {
            var dataEntity = await Task.FromResult(this.Entities.Update(entity));

            return dataEntity.Entity;
        }
    }
}