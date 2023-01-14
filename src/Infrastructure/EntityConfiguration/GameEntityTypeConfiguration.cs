// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEntityTypeConfiguration.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GameEntityTypeConfiguration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.EntityConfiguration
{
    using GameCollector.Domain.AggregateModels.Competition;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// <see cref="GameEntityTypeConfiguration"/>
    /// </summary>
    /// <seealso cref="EntityTypeConfiguration{Game}"/>
    internal class GameEntityTypeConfiguration : EntityTypeConfiguration<Game>
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        protected override string TableName => "Game";

        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureEntity(EntityTypeBuilder<Game> builder)
        {
            builder.Property(x => x.Score)
                .HasMaxLength(25);

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.TeamAId)
                .IsRequired();

            builder.Property(x => x.TeamBId)
                .IsRequired();

            builder.HasMany(f => f.Odds);
        }
    }
}