// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameLiveCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameLiveCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameLiveCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateGameLiveCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{UpdateGameLiveCommand, Game}"/>
    public class UpdateGameLiveCommandHandler : IRequestHandler<UpdateGameLiveCommand, Game>
    {
        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IGameRepository gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGameLiveCommandHandler"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        public UpdateGameLiveCommandHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="NotFoundException">The game with id {request.GameId} wasn't found.</exception>
        public async Task<Game> Handle(UpdateGameLiveCommand request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The game with id {request.GameId} wasn't found.");
            }

            game.UpdateLiveScore(request.Score);

            await this.gameRepository.Update(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return game;
        }
    }
}