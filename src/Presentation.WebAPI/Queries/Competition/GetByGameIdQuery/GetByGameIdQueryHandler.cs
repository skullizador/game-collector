// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByGameIdQueryHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByGameIdQueryHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Queries.Competition.GetByGameIdQuery
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="GetByGameIdQueryHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{GetByGameIdQuery, Game}"/>
    public class GetByGameIdQueryHandler : IRequestHandler<GetByGameIdQuery, Game>
    {
        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IGameRepository gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByGameIdQueryHandler"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        public GetByGameIdQueryHandler(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="NotFoundException">The Game with id {request.GameId} wasn't found.</exception>
        public async Task<Game> Handle(GetByGameIdQuery request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The Game with id {request.GameId} wasn't found.");
            }

            return game;
        }
    }
}