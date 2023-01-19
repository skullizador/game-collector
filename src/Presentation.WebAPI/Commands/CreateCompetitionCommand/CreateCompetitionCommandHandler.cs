// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCompetitionCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateCompetitionCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.CreateCompetitionCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Builder.CompetitionBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="CreateCompetitionCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{CreateCompetitionCommand, Competition}"/>
    public class CreateCompetitionCommandHandler : IRequestHandler<CreateCompetitionCommand, Competition>
    {
        /// <summary>
        /// The competition builder
        /// </summary>
        private readonly ICompetitionBuilder competitionBuilder;

        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompetitionCommandHandler"/> class.
        /// </summary>
        /// <param name="competitionBuilder">The competition builder.</param>
        /// <param name="competitionRepository">The competition repository.</param>
        public CreateCompetitionCommandHandler(
            ICompetitionBuilder competitionBuilder,
            ICompetitionRepository competitionRepository)
        {
            this.competitionBuilder = competitionBuilder;
            this.competitionRepository = competitionRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="DuplicatedException">
        /// The competition with name {request.Name} {request.Year} which takes place ate
        /// {request.Region} is duplicated.
        /// </exception>
        public async Task<Competition> Handle(CreateCompetitionCommand request, CancellationToken cancellationToken)
        {
            Competition competition = await competitionRepository
                .GetUniqueAsync(
                    request.Name,
                    request.Region,
                    request.Year,
                    request.Type,
                    request.Sport,
                    cancellationToken);

            if (competition is not null)
            {
                throw new DuplicatedException($"The competition with name {request.Name} {request.Year} which takes place ate {request.Region} is duplicated.");
            }

            competition = competitionBuilder
                .NewCompetition(
                    request.Name,
                    request.Year,
                    request.Region,
                    request.Description,
                    request.Sport,
                    request.Type)
                .Build();

            await competitionRepository.AddAsync(competition, cancellationToken);

            await competitionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return competition;
        }
    }
}