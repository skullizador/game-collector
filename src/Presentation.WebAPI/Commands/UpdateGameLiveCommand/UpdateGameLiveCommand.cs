// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameLiveCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameLiveCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameLiveCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateGameLiveCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Game}"/>
    public class UpdateGameLiveCommand : IRequest<Game>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGameLiveCommand"/> class.
        /// </summary>
        public UpdateGameLiveCommand()
        {
            this.Score = string.Empty;
        }

        /// <summary>
        /// Gets the game identifier.
        /// </summary>
        /// <value>The game identifier.</value>
        public Guid GameId { get; init; }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <value>The score.</value>
        public string Score { get; init; }
    }
}