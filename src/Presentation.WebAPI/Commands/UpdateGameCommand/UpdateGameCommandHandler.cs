// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateGameCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{UpdateGameCommand, Game}"/>
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Game>
    {
        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IGameRepository gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGameCommandHandler"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        public UpdateGameCommandHandler(IGameRepository gameRepository)
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
        public async Task<Game> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The game with id {request.GameId} wasn't found.");
            }

            game.Update(request.StartDate, request.TeamAId, request.TeamBId);

            await this.gameRepository.Update(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return game;
        }
    }
}