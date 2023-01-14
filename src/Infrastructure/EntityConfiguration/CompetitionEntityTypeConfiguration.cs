// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionEntityTypeConfiguration.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionEntityTypeConfiguration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Infrastructure.EntityConfiguration
{
    using System;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Enum;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// <see cref="CompetitionEntityTypeConfiguration"/>
    /// </summary>
    /// <seealso cref="EntityTypeConfiguration{Competition}"/>
    internal class CompetitionEntityTypeConfiguration : EntityTypeConfiguration<Competition>
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        protected override string TableName => "Competition";

        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureEntity(EntityTypeBuilder<Competition> builder)
        {
            builder.Property(f => f.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (CompetitionType)Enum.Parse(typeof(CompetitionType), v))
                .HasMaxLength(20);

            builder.Property(f => f.Sport)
                .HasConversion(
                    v => v.ToString(),
                    v => (SportsType)Enum.Parse(typeof(SportsType), v))
                .HasMaxLength(20);

            builder.Property(f => f.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.Region)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.Year)
                .IsRequired();

            builder.HasMany(f => f.Games);
        }
    }
}