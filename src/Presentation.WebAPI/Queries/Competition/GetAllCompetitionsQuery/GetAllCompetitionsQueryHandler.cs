// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllCompetitionsQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetAllCompetitionsQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetAllCompetitionsQuery
{
    using Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using MediatR;

    /// <summary>
    /// <see cref="GetAllCompetitionsQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetAllCompetitionsQuery, IEnumerable{Competition}}"/>
    public class GetAllCompetitionsQueryHandler : IRequestHandler<GetAllCompetitionsQuery, IEnumerable<Competition>>
    {
        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCompetitionsQueryHandler"/> class.
        /// </summary>
        /// <param name="competitionRepository">The competition repository.</param>
        public GetAllCompetitionsQueryHandler(ICompetitionRepository competitionRepository)
        {
            this.competitionRepository = competitionRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<IEnumerable<Competition>> Handle(GetAllCompetitionsQuery request, CancellationToken cancellationToken)
        {
            return await this.competitionRepository.GetAllAsync(cancellationToken);
        }
    }
}