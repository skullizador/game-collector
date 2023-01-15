// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCompetitionCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateCompetitionCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateCompetitionCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateCompetitionCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{UpdateCompetitionCommand, Competition}"/>
    public class UpdateCompetitionCommandHandler : IRequestHandler<UpdateCompetitionCommand, Competition>
    {
        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCompetitionCommandHandler"/> class.
        /// </summary>
        /// <param name="competitionRepository">The competition repository.</param>
        public UpdateCompetitionCommandHandler(ICompetitionRepository competitionRepository)
        {
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
        public async Task<Competition> Handle(UpdateCompetitionCommand request, CancellationToken cancellationToken)
        {
            Competition competition = await this.competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

            if (competition is null)
            {
                throw new NotFoundException($"The competition with id {request.CompetitionId} wasn't found.");
            }

            competition.Update(request.Description, request.Region, request.Year);

            await this.competitionRepository.Update(competition, cancellationToken);

            await this.competitionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return competition;
        }
    }
}