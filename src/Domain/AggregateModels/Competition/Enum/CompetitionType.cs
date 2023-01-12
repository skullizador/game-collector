// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionType.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionType
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.AggregateModels.Competition.Enum
{
    /// <summary>
    /// <see cref="CompetitionType"/>
    /// </summary>
    public enum CompetitionType
    {
        /// <summary>
        /// The league
        /// </summary>
        League = 1,

        /// <summary>
        /// The tournament
        /// </summary>
        Tournament = 2,

        /// <summary>
        /// The friendly
        /// </summary>
        Friendly = 3
    }
}