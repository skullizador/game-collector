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
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Builder.GameBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="CreateGameCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{CreateGameCommand, Game}"/>
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
    {
        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// The game builder
        /// </summary>
        private readonly IGameBuilder gameBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGameCommandHandler"/> class.
        /// </summary>
        /// <param name="gameBuilder">The game builder.</param>
        /// <param name="competitionRepository">The competition repository.</param>
        public CreateGameCommandHandler(
            IGameBuilder gameBuilder,
            ICompetitionRepository competitionRepository)
        {
            this.gameBuilder = gameBuilder;
            this.competitionRepository = competitionRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="NotFoundException">
        /// The competition with id {request.CompetitionId} wasn't found.
        /// </exception>
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
                    request.StartDate)
                .Build();

            competition.AddGame(game);

            await this.competitionRepository.Update(competition, cancellationToken);

            await this.competitionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return game;
        }
    }
}