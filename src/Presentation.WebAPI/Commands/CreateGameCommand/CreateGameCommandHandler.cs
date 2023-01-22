// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateGameCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateGameCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.CreateGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Builder.GameBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
    {
        private readonly IGameBuilder gameBuilder;

        private readonly ICompetitionRepository competitionRepository;

        public CreateGameCommandHandler(
            IGameBuilder gameBuilder, 
            ICompetitionRepository competitionRepository)
        {
            this.gameBuilder = gameBuilder;
            this.competitionRepository = competitionRepository;
        }

        public async Task<Game> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            Competition competition = await this.competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

            if (competition is null)
            {
                throw new NotFoundException($"The competition with id {request.CompetitionId} wasn't found.");
            }

            Game game = this.gameBuilder
                .NewGame(
                    request.TeamAId, 
                    request.TeamBId, 
                    request.Score, 
                    request.StartDate)
                .Build();

            competition.AddGame(game);

            await this.competitionRepository.Update(competition, cancellationToken);

            await this.competitionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return game;
        }
    }
}
