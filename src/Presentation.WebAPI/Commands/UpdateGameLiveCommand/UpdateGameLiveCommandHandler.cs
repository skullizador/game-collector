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
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateGameLiveCommandHandler : IRequestHandler<UpdateGameLiveCommand, Game>
    {
        private readonly IGameRepository gameRepository;

        public UpdateGameLiveCommandHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public async Task<Game> Handle(UpdateGameLiveCommand request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId,cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The game with id {request.GameId} wasn't found.");
            }
            game.UpdateLive(request.Score);

            await this.gameRepository.Update(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return game;
        }
    }
}
