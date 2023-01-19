// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteGameCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DeleteGameCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GameCollector.Presentation.WebAPI.Commands.DeleteGameCommand
{
    using MediatR;

    /// <summary>
    /// <see cref="DeleteGameCommand"/>
    /// </summary>
    /// <seealso cref="INotification" />
    public class DeleteGameCommand : INotification
    {
        /// <summary>
        /// The game identifier
        /// </summary>
        public Guid GameId { get; init; }
    }
}
