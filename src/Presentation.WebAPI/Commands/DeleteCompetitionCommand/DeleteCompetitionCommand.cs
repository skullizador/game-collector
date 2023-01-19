// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteCompetitionCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DeleteCompetitionCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.DeleteCompetitionCommand
{
    using MediatR;

    /// <summary>
    /// <see cref="DeleteCompetitionCommand"/>
    /// </summary>
    /// <seealso cref="INotification" />
    public class DeleteCompetitionCommand : INotification
    {
        /// <summary>
        /// Gets the competition identifier.
        /// </summary>
        /// <value>
        /// The competition identifier.
        /// </value>
        public Guid CompetitionId { get; init; }
    }
}
