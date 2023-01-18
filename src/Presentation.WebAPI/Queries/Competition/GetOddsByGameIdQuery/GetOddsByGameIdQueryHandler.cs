// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOddsByGameIdQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetOddsByGameIdQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetOddsByGameIdQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="GetOddsByGameIdQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetOddsByGameIdQuery, IEnumerable{Odd}}"/>
    public class GetOddsByGameIdQueryHandler : IRequestHandler<GetOddsByGameIdQuery, IEnumerable<Odd>>
    {
        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IGameRepository gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOddsByGameIdQueryHandler"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        public GetOddsByGameIdQueryHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        /// <summary> Handles a request </summary> <param name="request">The request</param> <param
        /// name="cancellationToken">Cancellation token</param> <returns>Response from the
        /// request</returns> <exception cref=NotFoundException"> The Game with id {request.GameId}
        /// wasn't found. </exception>
        public async Task<IEnumerable<Odd>> Handle(GetOddsByGameIdQuery request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The Game with id {request.GameId} wasn't found.");
            }

            return game.Odds;
        }
    }
}