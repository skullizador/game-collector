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
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Server.IIS.Core;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Game>
    {
        private readonly IGameRepository gameRepository;

        public UpdateGameCommandHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<Game> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The game with id {request.GameId} wasn't found.");
            }

            game.Update(request.Score, request.StartDate, request.TeamAId, request.TeamBId);

            await this.gameRepository.Update(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return game;
        }
    }
}
