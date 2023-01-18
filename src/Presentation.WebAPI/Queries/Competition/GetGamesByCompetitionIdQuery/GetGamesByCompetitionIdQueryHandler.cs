// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetGamesByCompetitionIdQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetGamesByCompetitionIdQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetGamesByCompetitionIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="GetGamesByCompetitionIdQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetGamesByCompetitionIdQuery, IEnumerable{Game}}"/>
    public class GetGamesByCompetitionIdQueryHandler : IRequestHandler<GetGamesByCompetitionIdQuery, IEnumerable<Game>>
    {
        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGamesByCompetitionIdQueryHandler"/> class.
        /// </summary>
        /// <param name="competitionRepository">The competition repository.</param>
        public GetGamesByCompetitionIdQueryHandler(ICompetitionRepository competitionRepository)
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
        public async Task<IEnumerable<Game>> Handle(GetGamesByCompetitionIdQuery request, CancellationToken cancellationToken)
        {
            Competition competition = await this.competitionRepository.GetAsync(request.CompetitionId, cancellationToken);

            if (competition is null)
            {
                throw new NotFoundException($"The Competition with id {request.CompetitionId} wasn't found.");
            }

            return competition.Games;
        }
    }
}