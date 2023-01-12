// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityTypeConfiguration.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// EntityTypeConfiguration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.EntityConfiguration
{
    using GameCollector.Domain.SeedWork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// <see cref="EntityTypeConfiguration"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IEntityTypeConfiguration{T}"/>
    internal abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        protected abstract string TableName { get; }

        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(this.TableName);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.CreationDate)
                .IsRequired();

            builder.Property(t => t.ModificationDate)
                .IsRequired()
                .IsConcurrencyToken();

            builder.Property(t => t.UUId)
                .IsRequired();

            this.ConfigureEntity(builder);

            builder.HasIndex(t => t.UUId)
                .IsUnique();

            builder.Ignore(t => t.DomainEvents);
        }

        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}