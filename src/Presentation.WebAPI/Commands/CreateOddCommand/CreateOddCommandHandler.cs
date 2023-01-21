// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateOddCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateOddCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.CreateOddCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Builder.OddBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateOddCommandHandler : IRequestHandler<CreateOddCommand, Odd>
    {
        private readonly IGameRepository gameRepository;

        private readonly IOddBuilder oddBuilder;

        public CreateOddCommandHandler(IGameRepository gameRepository, IOddBuilder oddBuilder)
        {
            this.gameRepository = gameRepository;
            this.oddBuilder = oddBuilder;
        }

        public async Task<Odd> Handle(CreateOddCommand request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The game with id {request.GameId} wasn't found.");
            }

            this.oddBuilder.NewOdd(request.BookmakerId, request.Type, request.Value);
             
            if(request.TeamId is not null)
            {
                this.oddBuilder.AddTeamId(request.TeamId);
            }

            Odd odd = this.oddBuilder.Build();

            game.AddOdd(odd);

            await this.gameRepository.Update(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return odd;
            
        }
    }
}
