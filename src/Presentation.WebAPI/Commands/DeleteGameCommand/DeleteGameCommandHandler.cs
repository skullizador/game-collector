// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteGameCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DeleteGameCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.DeleteGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// <see cref="DeleteGameCommandHandler"/>
    /// </summary>
    /// <seealso cref="INotificationHandler{DeleteGameCommand}" />
    public class DeleteGameCommandHandler : INotificationHandler<DeleteGameCommand>
    {
        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IGameRepository gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteGameCommandHandler"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        public DeleteGameCommandHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="NotFoundException">The Game with id {notification.GameId} wasn't found.</exception>
        public async Task Handle(DeleteGameCommand notification, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(notification.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The Game with id {notification.GameId} wasn't found.");
            }

            await this.gameRepository.Remove(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
