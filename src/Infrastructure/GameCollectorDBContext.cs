// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookmakerServiceDBContext.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// BookmakerServiceDBContext
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.SeedWork;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// <see cref="GameCollectorDBContext"/>
    /// </summary>
    /// <seealso cref="DbContext"/>
    /// <seealso cref="IUnitOfWork"/>
    public class GameCollectorDBContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// The database connection section
        /// </summary>
        private const string DatabaseConnectionSection = "DatabaseConnectionString";

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCollectorDBContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="mediator">The mediator.</param>
        public GameCollectorDBContext(
            IConfiguration configuration,
            IMediator mediator,
            DbContextOptions<GameCollectorDBContext> options)
            : base(options)
        {
            this.configuration = configuration;
            this.mediator = mediator;
        }

        /// <summary>
        /// Saves the entities asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await this.DispatchDomainEventsAsync();

            this.AddTimestamps();

            await this.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// Override this method to configure the database (and other options) to be used for this
        /// context. This method is called for each instance of the context that is created. The
        /// base implementation does nothing.
        /// </summary>
        /// <param name="optionsBuilder">
        /// A builder used to create or modify options for this context. Databases (and other
        /// extensions) typically define extension methods on this object that allow you to
        /// configure the context.
        /// </param>
        /// <remarks>
        /// <para>
        /// In situations where an instance of <see
        /// cref="T:Microsoft.EntityFrameworkCore.DbContextOptions"/> may or may not have been
        /// passed to the constructor, you can use <see
        /// cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured"/> to
        /// determine if the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)"/>.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration,
        /// and initialization</see> for more information and examples.
        /// </para>
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseMySql(
                    this.configuration.GetSection(GameCollectorDBContext.DatabaseConnectionSection).Value,
                    new MySqlServerVersion(new Version(8, 0, 28)));

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1"/>
        /// properties on your derived context. The resulting model may be cached and re-used for
        /// subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        /// The builder being used to construct the model for this context. Databases (and other
        /// extensions) typically define extension methods on this object that allow you to
        /// configure aspects of the model that are specific to a given database.
        /// </param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see
        /// cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)"/>)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and
        /// relationships</see> for more information and examples.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

            foreach (var property in properties)
            {
                property.SetColumnType("decimal(18,5)");
            }
        }

        /// <summary>
        /// Adds the timestamps.
        /// </summary>
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is EntityBase
                    && (x.State is EntityState.Added || x.State is EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State is EntityState.Added)
                {
                    ((EntityBase)entity.Entity).CreationDate = DateTime.UtcNow;
                }

                ((EntityBase)entity.Entity).ModificationDate = DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Dispatches the domain events asynchronous.
        /// </summary>
        private async Task DispatchDomainEventsAsync()
        {
            var domainEntities = this.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Any());

            var tasks = domainEntities.Select(async (domainEvent) =>
            {
                await this.mediator.Publish(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}