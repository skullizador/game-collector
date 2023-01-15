// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByOddIdQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByOddIdQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetByOddIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="GetByOddIdQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetByOddIdQuery, Odd}"/>
    public class GetByOddIdQueryHandler : IRequestHandler<GetByOddIdQuery, Odd>
    {
        /// <summary>
        /// The odd repository
        /// </summary>
        private readonly IOddRepository oddRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByOddIdQueryHandler"/> class.
        /// </summary>
        /// <param name="oddRepository">The odd repository.</param>
        public GetByOddIdQueryHandler(IOddRepository oddRepository)
        {
            this.oddRepository = oddRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="NotFoundException">The Odd with id {request.OddId} wasn't found.</exception>
        public async Task<Odd> Handle(GetByOddIdQuery request, CancellationToken cancellationToken)
        {
            Odd odd = await this.oddRepository.GetAsync(request.OddId, cancellationToken);

            if (odd is null)
            {
                throw new NotFoundException($"The Odd with id {request.OddId} wasn't found.");
            }

            return odd;
        }
    }
}