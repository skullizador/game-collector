// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateOddCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateOddCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateOddCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;

    /// <summary>
    /// <see cref="UpdateOddCommandHandler"/>
    /// </summary>
    /// <seealso cref="IRequestHandler{UpdateOddCommand, Odd}"/>
    public class UpdateOddCommandHandler : IRequestHandler<UpdateOddCommand, Odd>
    {
        /// <summary>
        /// The odd repository
        /// </summary>
        private readonly IOddRepository oddRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOddCommandHandler"/> class.
        /// </summary>
        /// <param name="oddRepository">The odd repository.</param>
        public UpdateOddCommandHandler(IOddRepository oddRepository)
        {
            this.oddRepository = oddRepository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        /// <exception cref="NotFoundException">The odd with id {request.OddId} wasn't found.</exception>
        public async Task<Odd> Handle(UpdateOddCommand request, CancellationToken cancellationToken)
        {
            Odd odd = await this.oddRepository.GetAsync(request.OddId, cancellationToken);

            if (odd is null)
            {
                throw new NotFoundException($"The odd with id {request.OddId} wasn't found.");
            }

            odd.Update(request.Value);

            await this.oddRepository.Update(odd, cancellationToken);

            await this.oddRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return odd;
        }
    }
}