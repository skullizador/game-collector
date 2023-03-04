// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateOddCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateOddCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.CreateOddCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Builder.OddBuilder;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="CreateOddCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{CreateOddCommand, Odd}"/>
    public class CreateOddCommandHandler : IRequestHandler<CreateOddCommand, Odd>
    {
        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IGameRepository gameRepository;

        /// <summary>
        /// The odd builder
        /// </summary>
        private readonly IOddBuilder oddBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOddCommandHandler"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        /// <param name="oddBuilder">The odd builder.</param>
        public CreateOddCommandHandler(IGameRepository gameRepository, IOddBuilder oddBuilder)
        {
            this.gameRepository = gameRepository;
            this.oddBuilder = oddBuilder;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="NotFoundException">The game with id {request.GameId} wasn't found.</exception>
        public async Task<Odd> Handle(CreateOddCommand request, CancellationToken cancellationToken)
        {
            Game game = await this.gameRepository.GetAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException($"The game with id {request.GameId} wasn't found.");
            }

            this.oddBuilder.NewOdd(request.BookmakerId, request.Type, request.Value);

            this.oddBuilder.AddTeamId(request.TeamId);

            Odd odd = this.oddBuilder.Build();

            game.AddOdd(odd);

            await this.gameRepository.Update(game, cancellationToken);

            await this.gameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return odd;
        }
    }
}