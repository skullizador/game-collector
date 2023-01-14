// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByCompetitionIdQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByCompetitionIdQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetByCompetitionIdQuery
{
    using Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="GetByCompetitionIdQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetByCompetitionIdQuery, Competition}"/>
    public class GetByCompetitionIdQueryHandler : IRequestHandler<GetByCompetitionIdQuery, Competition>
    {
        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByCompetitionIdQueryHandler"/> class.
        /// </summary>
        /// <param name="competitionRepository">The competition repository.</param>
        public GetByCompetitionIdQueryHandler(ICompetitionRepository competitionRepository)
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
        /// The Competition with id {request.CompetitionId} wasn't found.
        /// </exception>
        public async Task<Competition> Handle(GetByCompetitionIdQuery request, CancellationToken cancellationToken)
        {
            Competition competition = await this.competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

            if (competition == null)
            {
                throw new NotFoundException($"The Competition with id {request.CompetitionId} wasn't found.");
            }

            return competition;
        }
    }
}